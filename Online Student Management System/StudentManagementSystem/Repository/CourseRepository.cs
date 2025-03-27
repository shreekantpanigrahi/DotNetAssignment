using Microsoft.EntityFrameworkCore;
using OnlineStudentManagementSystem.Context;
using OnlineStudentManagementSystem.Models;
using OnlineStudentManagementSystem.Exception;

namespace OnlineStudentManagementSystem.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _context;

        public CourseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<Course> GetCourseByIdAsync(string id) // Changed from int to string
        {
            var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == id); // Updated to use string ID
            if (course == null)
            {
                throw new CourseNotFoundException($"The Course with ID {id} not Found");
            }
            return course;
        }

        public async Task AddCourseAsync(Course course)
        {
            try
            {
                _context.Courses.Add(course);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new ApplicationException("Error saving course to the database.", ex);
            }
        }

        public async Task UpdateCourseAsync(Course course)
        {
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCourseAsync(string id) // Changed from int to string
        {
            var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == id); // Updated to use string ID
            if (course != null)
            {
                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();
            }
        }
    }
}