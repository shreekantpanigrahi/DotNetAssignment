using OnlineStudentManagementSystem.Models;

namespace OnlineStudentManagementSystem.Repository
{
    public interface IEnrollmentRepository
    {
        Task EnrollStudentAsync(string studentId, string courseId);
        Task WithdrawStudentAsync(string studentId, string courseId);
        Task<IEnumerable<Enrollment>> GetEnrollmentsByStudentIdAsync(string studentId);
    }
}
