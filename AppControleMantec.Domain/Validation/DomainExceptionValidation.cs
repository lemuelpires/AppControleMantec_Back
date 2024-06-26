using System;

namespace AppControleMantec.Domain.Validation
{
    public static class DomainExceptionValidation
    {
        public static void When(bool condition, string message)
        {
            if (condition)
            {
                throw new DomainException(message);
            }
        }
    }

    public class DomainException : Exception
    {
        public DomainException()
        {
        }

        public DomainException(string message)
            : base(message)
        {
        }

        public DomainException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
