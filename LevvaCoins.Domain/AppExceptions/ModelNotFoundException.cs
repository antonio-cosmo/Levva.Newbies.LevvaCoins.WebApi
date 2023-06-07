namespace LevvaCoins.Domain.AppExceptions
{
    public class NotAuthorizedException : Exception
    {
        public NotAuthorizedException(string message = "Not authorized") : base(message) { }
    }
}
