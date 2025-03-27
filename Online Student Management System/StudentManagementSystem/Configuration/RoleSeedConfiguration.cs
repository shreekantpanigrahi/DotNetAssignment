using Microsoft.AspNetCore.Identity;
using OnlineStudentManagementSystem.Controllers;
namespace OnlineStudentManagementSystem.Configuration
{
    public static class RoleSeedConfiguration
    {
        public static async Task SeedRoleAsync(RoleManager<IdentityRole> roleManager)
        {
            string[] roles = { "Admin", "Teacher", "Student" };
            foreach(var role in roles)
            {
                if(!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
    }
}
