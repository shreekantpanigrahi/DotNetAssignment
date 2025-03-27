using Microsoft.AspNetCore.Mvc;
using OnlineStudentManagementSystem.Exception;
using OnlineStudentManagementSystem.Service;
using OnlineStudentManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace OnlineStudentManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly UserManager<ApplicationUser> _userManager;
        public StudentController(IStudentService studentService, UserManager<ApplicationUser> userManager)
        {
            _studentService = studentService;
            _userManager = userManager;
        }

        // GET: Student/Index (For Teachers)
        [Authorize(Roles = "Teacher,Admin")]
        public async Task<IActionResult> Index()
        {
            var students = await _studentService.GetAllStudentAsync();
            return View(students);
        }

        // GET: Student/Details
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Details(string id) 
        {
            try
            {
                if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out _))
                {
                    return BadRequest("Invalid student ID.");
                }

                var student = await _studentService.GetStudentByIdAsync(id); 
                return View(student);
            }
            catch (StudentNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET: Student/Create
        [HttpGet]
        public IActionResult Create(string id)
        {
            Student student = new Student
            {
                Id = id
            };
            return View(student);
        }

        // POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student)
        {
            ModelState.Remove("Enrollments");
            if (!ModelState.IsValid)
            {
                return View(student);
            }

            try
            {
                await _studentService.AddStudentAsync(student);
                return RedirectToAction("Login","Account");
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(student);
            }
        }

        // GET: Student/Edit
        [Authorize(Roles = "Student")]
        [HttpGet]
        public async Task<IActionResult> Edit(string id) 
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null || string.IsNullOrEmpty(user.Id))
                {
                    return BadRequest("User not found.");
                }

                var student = await _studentService.GetStudentByIdAsync(user.Id); 
                return View(student);
            }
            catch (StudentNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: Student/Edit

        [HttpPost]
        public async Task<IActionResult> Edit(string id, Student student) 
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value; 

            if (string.IsNullOrEmpty(userId) || !Guid.TryParse(userId, out _))
            {
                return BadRequest("Invalid user ID.");
            }

            if (id != student.Id)
            {
                return BadRequest("Mismatched student ID.");
            }

            if (!ModelState.IsValid)
            {
                return View(student);
            }

            try
            {
                await _studentService.UpdateStudentAsync(student);
                return RedirectToAction(nameof(Index));
            }
            catch (StudentNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(student);
            }
        }

        // GET: Student/Delete
        [HttpGet]
        public async Task<IActionResult> Delete(string id) 
        {
            try
            {
                if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out _))
                {
                    return BadRequest("Invalid student ID.");
                }

                var student = await _studentService.GetStudentByIdAsync(id); 
                return View(student);
            }
            catch (StudentNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: Student/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id) 
        {
            try
            {
                if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out _))
                {
                    return BadRequest("Invalid student ID.");
                }

                await _studentService.DeleteStudentAsync(id); 
                return RedirectToAction(nameof(Index));
            }
            catch (StudentNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}