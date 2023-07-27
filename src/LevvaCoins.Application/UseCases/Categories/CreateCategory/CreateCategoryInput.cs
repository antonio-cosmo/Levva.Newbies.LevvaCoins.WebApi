using LevvaCoins.Application.UseCases.Categories.Common;
using MediatR;

namespace LevvaCoins.Application.UseCases.Categories.CreateCategory;

public class CreateCategoryInput : IRequest<CategoryModelOutput>
{
    public string Description { get; set; }
    public CreateCategoryInput(string description)
    {
        Description = description;
    }
}
