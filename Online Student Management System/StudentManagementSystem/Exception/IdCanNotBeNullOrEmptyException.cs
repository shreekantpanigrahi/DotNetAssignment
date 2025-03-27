namespace OnlineStudentManagementSystem.Exception
{
    public class IdCanNotBeNullOrEmptyException:ApplicationException
    {
        public IdCanNotBeNullOrEmptyException()
        {
        }
        public IdCanNotBeNullOrEmptyException(string message) : base()
        {
        }
        public IdCanNotBeNullOrEmptyException(string? message, System.Exception? innerException) : base(message, innerException)
        {
        }
    }
}

