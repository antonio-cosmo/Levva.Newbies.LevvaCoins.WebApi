namespace LevvaCoins.Application.Common.Dtos
{
    public class ErrorResponse
    {
        public bool HasError { get; set; }
        public string? Message { get; set; }
    }
}
