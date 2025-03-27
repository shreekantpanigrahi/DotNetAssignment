using OnlineStudentManagementSystem.Models;

namespace OnlineStudentManagementSystem.Service
{
    public interface IEnrollmentService
    {
        Task EnrollStudentAsync(string studentId, string courseId);
        Task WithdrawStudentAsync(string studentId, string courseId);
        Task<IEnumerable<Enrollment>> GetEnrollmentsByStudentIdAsync(string studentId);
    }
}
