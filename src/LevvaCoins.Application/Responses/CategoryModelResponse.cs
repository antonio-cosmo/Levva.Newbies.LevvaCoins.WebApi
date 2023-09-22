using LevvaCoins.Domain.Entities;

namespace LevvaCoins.Application.Responses;

public class CategoryModelResponse
{
    public CategoryModelResponse(Guid id, string description)
    {
        Id = id;
        Description = description;
    }

    public Guid Id { get; set; }
    public string Description { get; set; }

    public static CategoryModelResponse FromDomain(Category category)
    {
        return new CategoryModelResponse(
            category.Id,
            category.Description
        );
    }

    public static IEnumerable<CategoryModelResponse> FromDomain(IEnumerable<Category> categories)
    {
        return categories.Select(FromDomain);
    }
}