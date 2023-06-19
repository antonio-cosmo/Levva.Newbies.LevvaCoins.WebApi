namespace LevvaCoins.Domain.Validation
{
    public class DomainExceptionValidation : Exception
    {
        public DomainExceptionValidation() : base()
        {
        }

        public DomainExceptionValidation(string message) : base(message)
        {
        }

        public DomainExceptionValidation(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        public static void When(bool hasError, string errorMessage)
        {
            if (hasError)
            {
                throw new DomainExceptionValidation(errorMessage);
            }
        }
    }
}
