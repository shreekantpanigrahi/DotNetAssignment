using OnlineStudentManagementSystem.Context;
using OnlineStudentManagementSystem.Models;
using OnlineStudentManagementSystem.Repository;
using OnlineStudentManagementSystem.Exception;

namespace OnlineStudentManagementSystem.Service
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;

        public EnrollmentService(
            IEnrollmentRepository enrollmentRepository,
            IStudentRepository studentRepository,
            ICourseRepository courseRepository)
        {
            _enrollmentRepository = enrollmentRepository;
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
        }

        // Validate GUID
        private static void ValidateId(string id, string entityName)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out _))
            {
                throw new IdCanNotBeNullOrEmptyException($"{entityName} ID must be a valid GUID.");
            }
        }

        public async Task EnrollStudentAsync(string studentId, string courseId)
        {
            ValidateId(studentId, "Student");
            ValidateId(courseId, "Course");

            var studentExists = await _studentRepository.GetStudentByIdAsync(studentId) != null;
            var courseExists = await _courseRepository.GetCourseByIdAsync(courseId) != null;

            if (!studentExists)
            {
                throw new StudentNotFoundException($"Student with ID {studentId} not found.");
            }

            if (!courseExists)
            {
                throw new CourseNotFoundException($"Course with ID {courseId} not found.");
            }

            try
            {
                await _enrollmentRepository.EnrollStudentAsync(studentId, courseId);
            }
            catch (ApplicationException ex)
            {
                throw new InvalidOperationException("An error occurred while enrolling the student.", ex);
            }
        }

        public async Task WithdrawStudentAsync(string studentId, string courseId)
        {
            ValidateId(studentId, "Student");
            ValidateId(courseId, "Course");

            var studentExists = await _studentRepository.GetStudentByIdAsync(studentId) != null;
            var courseExists = await _courseRepository.GetCourseByIdAsync(courseId) != null;

            if (!studentExists)
            {
                throw new StudentNotFoundException($"Student with ID {studentId} not found.");
            }

            if (!courseExists)
            {
                throw new CourseNotFoundException($"Course with ID {courseId} not found.");
            }

            try
            {
                await _enrollmentRepository.WithdrawStudentAsync(studentId, courseId);
            }
            catch (ApplicationException ex)
            {
                throw new InvalidOperationException("An error occurred while withdrawing the student.", ex);
            }
        }

        public async Task<IEnumerable<Enrollment>> GetEnrollmentsByStudentIdAsync(string studentId)
        {
            ValidateId(studentId, "Student");

            var studentExists = await _studentRepository.GetStudentByIdAsync(studentId) != null;

            if (!studentExists)
            {
                throw new StudentNotFoundException($"Student with ID {studentId} not found.");
            }

            try
            {
                return await _enrollmentRepository.GetEnrollmentsByStudentIdAsync(studentId);
            }
            catch (ApplicationException ex)
            {
                throw new InvalidOperationException("An error occurred while fetching enrollments.", ex);
            }
        }
    }
}