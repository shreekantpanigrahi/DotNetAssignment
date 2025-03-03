using System;

namespace Question_1.Exceptions
{
    public class InvalidFormatException : Exception
    {
        
            public InvalidFormatException(string message) : base(message) { }
    }
}
