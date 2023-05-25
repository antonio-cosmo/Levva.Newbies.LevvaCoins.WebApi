namespace LevvaCoins.Domain.AppExceptions
{
    public class ModelAlreadyExistsException : Exception
    {
        public ModelAlreadyExistsException(string message = "Model already exists") : base(message) { }

    }
}
