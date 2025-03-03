using System;


namespace Question_1.Exceptions
{
    public class KeyNotContainException : Exception
    {
        public KeyNotContainException(string message) : base(message)
        {
        }
    }
}
