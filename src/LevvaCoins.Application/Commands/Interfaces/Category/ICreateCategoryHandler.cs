using LevvaCoins.Application.Commands.Requests.Category;
using LevvaCoins.Application.Responses;
using MediatR;

namespace LevvaCoins.Application.Commands.Interfaces.Category;

public interface ICreateCategoryHandler : IRequestHandler<CreateCategoryRequest, CategoryModelResponse?>
{
}