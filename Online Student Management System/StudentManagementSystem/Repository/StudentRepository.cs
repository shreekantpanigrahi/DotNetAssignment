using Microsoft.EntityFrameworkCore;
using OnlineStudentManagementSystem.Context;
using OnlineStudentManagementSystem.Models;
using OnlineStudentManagementSystem.Exception;

namespace OnlineStudentManagementSystem.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> GetStudentByIdAsync(string id) // Changed from int to string
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.Id == id); // Updated to use string ID
            if (student == null)
            {
                throw new StudentNotFoundException($"Student with ID {id} not Found");
            }
            return student;
        }

        public async Task AddStudentAsync(Student student)
        {
            try
            {
                _context.Students.Add(student);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new ApplicationException("Error saving student to the database.", ex);
            }
        }

        public async Task UpdateStudentAsync(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStudentAsync(string id) // Changed from int to string
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.Id == id); // Updated to use string ID
            if (student == null)
            {
                throw new StudentNotFoundException($"Student with ID {id} not Found");
            }
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }
    }
}