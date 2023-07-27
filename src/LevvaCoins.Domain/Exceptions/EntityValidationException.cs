namespace LevvaCoins.Domain.Exceptions;
public class EntityValidationException : Exception
{
    public EntityValidationException() : base()
    {
    }

    public EntityValidationException(string? message) : base(message)
    {
    }

    public EntityValidationException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
