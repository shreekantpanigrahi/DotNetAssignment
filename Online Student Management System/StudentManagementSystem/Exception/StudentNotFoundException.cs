namespace OnlineStudentManagementSystem.Exception
{
    public class StudentNotFoundException: ApplicationException
    {
        public StudentNotFoundException()
        {

        }

        public StudentNotFoundException(string message) : base()
        {

        }

        public StudentNotFoundException(string? message, System.Exception? innerException) : base(message, innerException)
        {
        }
    }
}
