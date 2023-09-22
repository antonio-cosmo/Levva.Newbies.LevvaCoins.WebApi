using LevvaCoins.Application.Responses;
using MediatR;

namespace LevvaCoins.Application.Commands.Requests.Category;

public class CreateCategoryRequest : IRequest<CategoryModelResponse?>
{
    public CreateCategoryRequest(string description)
    {
        Description = description;
    }

    public string Description { get; set; }
}