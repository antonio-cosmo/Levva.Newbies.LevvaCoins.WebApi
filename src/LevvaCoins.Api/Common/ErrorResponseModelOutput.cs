namespace LevvaCoins.Api.Common;

public class ErrorResponseModelOutput
{
    public bool HasError { get; set; }
    public string Message { get; set; }

    public ErrorResponseModelOutput(bool hasError, string message)
    {
        HasError = hasError;
        Message = message;
    }
}
