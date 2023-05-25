namespace LevvaCoins.Domain.Validation
{
    public class DomainExceptionValidation : Exception
    {
        public DomainExceptionValidation(string message) : base(message) { }

        public static void When(bool hasError, string errorMessage)
        {
            if (hasError)
            {
                throw new DomainExceptionValidation(errorMessage);
            }
        }
    }
}
