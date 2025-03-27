using System.Runtime.CompilerServices;

namespace OnlineStudentManagementSystem.Models
{
    public class Enrollment
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string StudentId { get; set; }
        public Student Student { get; set; }
        public string CourseId { get; set; }
        public Course Course { get; set; }
        public string Grade { get; set; }
    }
}
