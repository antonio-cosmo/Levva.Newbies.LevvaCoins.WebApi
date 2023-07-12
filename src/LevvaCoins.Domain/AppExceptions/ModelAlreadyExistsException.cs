namespace LevvaCoins.Domain.AppExceptions
{
    public class ModelAlreadyExistsException : Exception
    {
        public ModelAlreadyExistsException() : base()
        {
        }
        public ModelAlreadyExistsException(string? message) : base(message)
        {
        }

        public ModelAlreadyExistsException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
