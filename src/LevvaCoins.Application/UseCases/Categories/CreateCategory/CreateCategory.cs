using LevvaCoins.Application.Services.Dtos.Category;
using MediatR;

namespace LevvaCoins.Application.UseCases.Categories.CreateCategory;

public class CreateCategory : IRequest<CategoryModelResponse>
{
    public string Description { get; set; }
    public CreateCategory(string description)
    {
        Description = description;
    }
}
