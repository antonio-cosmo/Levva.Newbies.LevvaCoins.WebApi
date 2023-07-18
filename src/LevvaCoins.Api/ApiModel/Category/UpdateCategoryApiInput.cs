namespace LevvaCoins.Api.ApiModel.Category;

public class UpdateCategoryApiInput
{
    public string Description { get; set; }
    public UpdateCategoryApiInput(string description)
    {
        Description = description;
    }
}
