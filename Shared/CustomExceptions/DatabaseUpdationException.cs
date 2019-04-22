using System;

namespace Shared.CustomExceptions
{
    public class DatabaseUpdationException : Exception
    {
        public DatabaseUpdationException(string message) : base(message)
        {

        }
    }
}
