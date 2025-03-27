using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineStudentManagementSystem.Exception;
using OnlineStudentManagementSystem.Models;
using OnlineStudentManagementSystem.Service;

namespace OnlineStudentManagementSystem.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        // GET: Course/Index
        [Authorize(Roles = "Teacher, Admin")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var courses = await _courseService.GetAllCoursesAsync();
                if (courses == null)
                {
                    courses = new List<Course>();
                }
                return View("Index", courses);
            }
            catch (ApplicationException ex)
            {
                ModelState.AddModelError("", $"An error occurred: {ex.Message}");
                return View("Error");
            }
        }

        // GET: Course/StudentIndex
       [Authorize(Roles = "Student")]
        [HttpGet]
        public async Task<IActionResult> StudentIndex()
        {
            try
            {
                var courses = await _courseService.GetAllCoursesAsync();
                if (courses == null)
                {
                    courses = new List<Course>();
                }
                return View("StudentIndex", courses); 
            }
            catch (ApplicationException ex)
            {
                ModelState.AddModelError("", $"An error occurred: {ex.Message}");
                return View("Error");
            }
        }

        // GET: Course/Details
        [Authorize(Roles = "Student,Teacher,Admin")]
        [HttpGet]
        public async Task<IActionResult> Details(string id) 
        {
            try
            {
                var course = await _courseService.GetCourseByIdAsync(id); 
                return View(course);
            }
            catch (CourseNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET: Course/Create
        [Authorize(Roles = "Teacher, Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Course/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Course course)
        {
            ModelState.Remove("Enrollments");
            if (!ModelState.IsValid)
            {
                return View(course);
            }

            try
            {
                await _courseService.AddCourseAsync(course);
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(course);
            }
        }

        // GET: Course/Edit
        [Authorize(Roles = "Teacher, Admin")]
        [HttpGet]
        public async Task<IActionResult> Edit(string id) 
        {
            try
            {
                var course = await _courseService.GetCourseByIdAsync(id); 
                return View(course);
            }
            catch (CourseNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: Course/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Course course) 
        {
            if (id != course.Id)
            {
                return BadRequest("Mismatched course ID.");
            }

            if (!ModelState.IsValid)
            {
                return View(course);
            }

            try
            {
                await _courseService.UpdateCourseAsync(course);
                return RedirectToAction(nameof(Index));
            }
            catch (CourseNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(course);
            }
        }

        // GET: Course/Delete
        [Authorize(Roles = "Teacher, Admin")]
        [HttpGet]
        public async Task<IActionResult> Delete(string id) 
        {
            try
            {
                var course = await _courseService.GetCourseByIdAsync(id); 
                return View(course);
            }
            catch (CourseNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: Course/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id) 
        {
            try
            {
                await _courseService.DeleteCourseAsync(id); 
                return RedirectToAction(nameof(Index));
            }
            catch (CourseNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}