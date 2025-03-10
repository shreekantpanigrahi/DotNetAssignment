using System;

namespace InsuranceConsoleApp.Exceptions
{
    public class PolicyNotFoundException:Exception
    {
        public PolicyNotFoundException():base("The specified Policy id is not found"){ } //By default value 
        public PolicyNotFoundException(string message) : base(message) { }
        public PolicyNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}
