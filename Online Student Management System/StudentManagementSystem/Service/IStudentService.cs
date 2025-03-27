using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using OnlineStudentManagementSystem.Models;

namespace OnlineStudentManagementSystem.Service
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllStudentAsync();
        Task<Student> GetStudentByIdAsync(string id);
        Task AddStudentAsync(Student student);
        Task UpdateStudentAsync(Student student);
        Task DeleteStudentAsync(string id);

    }
}
