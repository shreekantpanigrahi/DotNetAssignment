using Microsoft.AspNetCore.Mvc;
using OnlineStudentManagementSystem.Models;
using OnlineStudentManagementSystem.Service;
using OnlineStudentManagementSystem.Exception;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace OnlineStudentManagementSystem.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly IEnrollmentService _enrollmentService;
        private readonly UserManager<ApplicationUser> _userManager;

        public EnrollmentController(IEnrollmentService enrollmentService, UserManager<ApplicationUser> userManager)
        {
            _enrollmentService = enrollmentService;
            _userManager = userManager;
        }

        // GET: Enrollment/StudentIndex (For Students)
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> StudentIndex()
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null || string.IsNullOrEmpty(user.Id))
                {
                    return BadRequest("User not found.");
                }

                var enrollments = await _enrollmentService.GetEnrollmentsByStudentIdAsync(user.Id);
                return View(enrollments);
            }
            catch (ApplicationException ex)
            {
                ModelState.AddModelError("", $"An error occurred: {ex.Message}");
                return View("Error");
            }
        }

        // GET: Enrollment/Index (For Admins and Teachers)
        [Authorize(Roles = "Admin, Teacher")]
        public async Task<IActionResult> Index(string studentId) 
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null || string.IsNullOrEmpty(user.Id))
                {
                    return BadRequest("User not found.");
                }

                var enrollments = await _enrollmentService.GetEnrollmentsByStudentIdAsync(user.Id);
                ViewBag.StudentId = studentId;
                return View("Index", enrollments);
            }
            catch (IdCanNotBeNullOrEmptyException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (StudentNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET: Enrollment/Enroll
        public IActionResult Enroll()
        {
            return View();
        }

        // POST: Enrollment/Enroll
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Enroll(string studentId, string courseId) // Changed from int to string
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                if (string.IsNullOrEmpty(studentId) || !Guid.TryParse(studentId, out _) ||
                    string.IsNullOrEmpty(courseId) || !Guid.TryParse(courseId, out _))
                {
                    ModelState.AddModelError("", "Invalid student or course ID.");
                    return View();
                }

                await _enrollmentService.EnrollStudentAsync(studentId, courseId);
                return RedirectToAction(nameof(Index), new { studentId });
            }
            catch (IdCanNotBeNullOrEmptyException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
            catch (StudentNotFoundException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
            catch (CourseNotFoundException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        // GET: Enrollment/Withdraw
        public IActionResult Withdraw(string studentId, string courseId) // Changed from int to string
        {
            if (string.IsNullOrEmpty(studentId) || !Guid.TryParse(studentId, out _) ||
                string.IsNullOrEmpty(courseId) || !Guid.TryParse(courseId, out _))
            {
                return BadRequest("Invalid student or course ID.");
            }

            ViewBag.StudentId = studentId;
            ViewBag.CourseId = courseId;
            return View();
        }

        // POST: Enrollment/Withdraw
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Withdraw(string studentId, string courseId, bool confirm) // Changed from int to string
        {
            if (!confirm)
            {
                return BadRequest("Withdrawal not confirmed.");
            }

            try
            {
                if (string.IsNullOrEmpty(studentId) || !Guid.TryParse(studentId, out _) ||
                    string.IsNullOrEmpty(courseId) || !Guid.TryParse(courseId, out _))
                {
                    ModelState.AddModelError("", "Invalid student or course ID.");
                    return View();
                }

                await _enrollmentService.WithdrawStudentAsync(studentId, courseId);
                return RedirectToAction(nameof(Index), new { studentId });
            }
            catch (IdCanNotBeNullOrEmptyException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
            catch (StudentNotFoundException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
            catch (CourseNotFoundException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }
    }
}