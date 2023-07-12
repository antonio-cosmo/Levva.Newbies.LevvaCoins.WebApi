namespace LevvaCoins.Domain.Shared.Validations
{
    public partial class ValidationRule
    {
        public ValidationRule IsNotNull(string val, string key, string message)
        {
            if (string.IsNullOrWhiteSpace(val))
            {
                AddNotification(key, message);
            }

            return this;
        }
    }
}
