using System;

namespace EudonetExercice.Exceptions
{
    public class DuplicateClientException : Exception
    {
        public DuplicateClientException()
        {
        }

        public DuplicateClientException(string email)
            : base($"This client aleady exists: ({email})")
        {
        }
    }
}
