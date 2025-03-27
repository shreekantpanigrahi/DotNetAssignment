namespace OnlineStudentManagementSystem.Exception
{
    public class CourseNotFoundException:ApplicationException
    {
        public CourseNotFoundException()
        {
        }
        public CourseNotFoundException(string message) : base()
        {
        }
        public CourseNotFoundException(string? message, System.Exception? innerException) : base(message, innerException)
        {

        }

    }
}
