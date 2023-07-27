namespace LevvaCoins.Application.Exceptions;
public class ModelAlreadyExistsException : Exception
{
    public ModelAlreadyExistsException()
    {
    }
    public ModelAlreadyExistsException(string? message) : base(message)
    {
    }

    public ModelAlreadyExistsException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
