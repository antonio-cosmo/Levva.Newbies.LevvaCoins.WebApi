namespace LevvaCoins.Api.Common;

public class ErrorResponse
{
    public bool HasError { get; set; }
    public string Message { get; set; }

    public ErrorResponse(bool hasError, string message)
    {
        HasError = hasError;
        Message = message;
    }
}
