using Microsoft.EntityFrameworkCore;
using OnlineStudentManagementSystem.Context;
using OnlineStudentManagementSystem.Models;

namespace OnlineStudentManagementSystem.Repository
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly AppDbContext _context;

        public EnrollmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task EnrollStudentAsync(string studentId, string courseId) // Changed from int to string
        {
            var enrollment = new Enrollment
            {
                StudentId = studentId,
                CourseId = courseId
            };
            _context.Enrollments.Add(enrollment);
            await _context.SaveChangesAsync();
        }

        public async Task WithdrawStudentAsync(string studentId, string courseId) // Changed from int to string
        {
            var enrollment = await _context.Enrollments.FirstOrDefaultAsync(e => e.StudentId == studentId && e.CourseId == courseId);
            if (enrollment == null)
            {
                throw new ApplicationException("Enrollment not found.");
            }

            _context.Enrollments.Remove(enrollment);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Enrollment>> GetEnrollmentsByStudentIdAsync(string studentId) // Changed from int to string
        {
            return await _context.Enrollments.Where(e => e.StudentId == studentId).ToListAsync(); // Updated to use string ID
        }
    }
}