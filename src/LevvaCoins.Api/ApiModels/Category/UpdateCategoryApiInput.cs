namespace LevvaCoins.Api.ApiModels.Category;

public class UpdateCategoryApiInput
{
    public string Description { get; set; }
    public UpdateCategoryApiInput(string description)
    {
        Description = description;
    }
}
