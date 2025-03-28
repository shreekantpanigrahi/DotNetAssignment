﻿using OnlineStudentManagementSystem.Models;

namespace OnlineStudentManagementSystem.Repository
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<Student> GetStudentByIdAsync(string id);
        Task AddStudentAsync(Student student);
        Task UpdateStudentAsync(Student student);
        Task DeleteStudentAsync(string id);

    }
}
