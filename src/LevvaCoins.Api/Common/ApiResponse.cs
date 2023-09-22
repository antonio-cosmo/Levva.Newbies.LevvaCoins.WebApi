namespace LevvaCoins.Api.Common;

public class ApiResponse
{
    public ApiResponse(bool success, object? data, ICollection<object> errors)
    {
        Success = success;
        Data = data;
        Errors = errors;
    }

    public bool Success { get; set; }
    public object? Data { get; set; }
    public ICollection<object> Errors { get; set; }
}