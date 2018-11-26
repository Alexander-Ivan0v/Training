using System;

namespace Training.ErrorHandling
{
    public class MyUnauthorizedException : Exception
    {   
        public MyUnauthorizedException(string message) : base(message)
        {
        }
    }
}
