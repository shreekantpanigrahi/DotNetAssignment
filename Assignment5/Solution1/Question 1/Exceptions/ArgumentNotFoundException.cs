using System;


namespace Question_1.Exceptions
{
    public class ArgumentNotFoundException : Exception
    {
        public ArgumentNotFoundException(string message) : base(message)
        {
        }

    }
}
