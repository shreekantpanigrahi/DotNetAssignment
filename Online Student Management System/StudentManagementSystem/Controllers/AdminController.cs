using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineStudentManagementSystem.Models;
using OnlineStudentManagementSystem.Service;
using OnlineStudentManagementSystem.ViewModels;


namespace OnlineStudentManagementSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ICourseService _courseService;

        public AdminController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ICourseService courseService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _courseService = courseService;
        }

        // GET: Admin/Users
        public async Task<IActionResult> Users()
        {
            var users = await _userManager.Users.ToListAsync();
            return View(users);
        }

        // GET: Admin/ManageRoles
        public async Task<IActionResult> ManageRoles(string userId)
        {
            if (string.IsNullOrEmpty(userId) || !Guid.TryParse(userId, out _))
            {
                return NotFound("Invalid User ID.");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            var userRoles = await _userManager.GetRolesAsync(user);
            var allRoles = await _roleManager.Roles.ToListAsync();

            ViewBag.UserId = userId;
            ViewBag.UserRoles = userRoles;
            return View(allRoles);
        }

        // POST: Admin/ManageRoles
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ManageRoles(string userId, string role)
        {
            if (string.IsNullOrEmpty(userId) || !Guid.TryParse(userId, out _))
            {
                return NotFound("Invalid User ID.");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            var existingRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, existingRoles); 
            await _userManager.AddToRoleAsync(user, role); 

            return RedirectToAction(nameof(Users));
        }

        
        
        [HttpGet]
        public async Task<IActionResult> ManageCourses(string tab = "ViewAll", string courseId = null)
        {
            var model = new ManageCoursesViewModel { SelectedTab = "ViewAll" };

            if (tab == "ViewAll")
            {
                var courses = await _courseService.GetAllCoursesAsync();
                ViewData["Courses"] = courses;
            }
            else if (tab == "Create")
            {
                ViewData["Course"] = new Course(); 
            }
            else if ((tab == "Edit" || tab == "Delete") && !string.IsNullOrEmpty(courseId))
            {
                var course = await _courseService.GetCourseByIdAsync(courseId); 
                if (course == null)
                {
                    return NotFound("Course not found.");
                }

                ViewData["Course"] = course;
            }

            return View(model);
        }

    }
}