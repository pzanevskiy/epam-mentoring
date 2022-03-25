using System;
using System.Collections.Generic;
using System.Text;

namespace Task3.Exceptions
{
    public class DuplicateTaskException : Exception
    {
        public DuplicateTaskException()
        {
        }

        public DuplicateTaskException(string? message) : base(message)
        {
        }

        public DuplicateTaskException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
