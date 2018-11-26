using System;

namespace Training.ErrorHandling
{
    public class MyNotFoundException : Exception
    {
        public MyNotFoundException(string message) : base(message)
        {
        }
    }
}
