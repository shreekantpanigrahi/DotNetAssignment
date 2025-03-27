using OnlineStudentManagementSystem.Exception;
using OnlineStudentManagementSystem.Models;
using OnlineStudentManagementSystem.Repository;
namespace OnlineStudentManagementSystem.Service
    
{
    public class StudentService:IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<IEnumerable<Student>> GetAllStudentAsync()
        {
            return await _studentRepository.GetAllStudentsAsync();
        }

        public async Task<Student> GetStudentByIdAsync(string id)
        {
            var student = await _studentRepository.GetStudentByIdAsync(id);
            if (student == null)
            {
                throw new StudentNotFoundException($"Student with ID {id} not found.");
            }
            return student;
        }

        public async Task AddStudentAsync(Student student)
        {
            var existingStudent = await _studentRepository.GetAllStudentsAsync();
            if (existingStudent.Any(s => s.Email == student.Email))
            {
                throw new InvalidOperationException("A student with this email already exist.");
            }

            await _studentRepository.AddStudentAsync(student);
        }

        public async Task UpdateStudentAsync(Student student)
        {
            var existingStudent = await _studentRepository.GetStudentByIdAsync(student.Id);
            if (existingStudent == null)
            {
                throw new StudentNotFoundException($"Student with ID{student.Id} not found.");
            }
            await _studentRepository.UpdateStudentAsync(student);
        }

        public async Task DeleteStudentAsync(string id)
        {
            var student = await _studentRepository.GetStudentByIdAsync(id);
            if (student == null)
            {
                throw new StudentNotFoundException($"Student with ID {id} not found");
            }
            await _studentRepository.DeleteStudentAsync(id);
        }
    }
}
