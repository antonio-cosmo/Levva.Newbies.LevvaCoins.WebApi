namespace LevvaCoins.Domain.AppExceptions
{
    public class ModelNotFoundException: Exception
    {
        public ModelNotFoundException(string message = "Model not found") : base(message) { }
    }
}
