using OnlineStudentManagementSystem.Models;
using OnlineStudentManagementSystem.Repository;
using OnlineStudentManagementSystem.Exception;

namespace OnlineStudentManagementSystem.Service
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            return await _courseRepository.GetAllCoursesAsync();
        }
        public async Task<Course> GetCourseByIdAsync(string id)
        {
            var course = await _courseRepository.GetCourseByIdAsync(id);
            return course;
        }
        public async Task AddCourseAsync(Course course)
        {
            var existingCourse = await _courseRepository.GetAllCoursesAsync();
            if (existingCourse.Any(c => c.CourseName == course.CourseName))
            {
                throw new InvalidOperationException("A course with this name already exists.");
            }

            await _courseRepository.AddCourseAsync(course);
        }
        public async Task UpdateCourseAsync(Course course)
        {
            var existingCourse = await _courseRepository.GetCourseByIdAsync(course.Id);
            if (existingCourse == null)
            {
                throw new CourseNotFoundException($"Course with ID {course.Id} not found.");
            }

            await _courseRepository.UpdateCourseAsync(course);
        }
        public async Task DeleteCourseAsync(string id)
        {
            var course = await _courseRepository.GetCourseByIdAsync(id);
            if (course == null)
            {
                throw new CourseNotFoundException($"Course with ID {id} not found.");
            }
            await _courseRepository.DeleteCourseAsync(id);
        }
    }
}
