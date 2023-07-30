namespace LevvaCoins.Application.Services.Dtos.Category;
public class CreateCategoryRequest
{
    public string Description { get; set; }
    public CreateCategoryRequest(string description)
    {
        Description = description;
    }
}
