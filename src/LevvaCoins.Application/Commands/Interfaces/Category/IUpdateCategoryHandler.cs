using LevvaCoins.Application.Commands.Requests.Category;
using MediatR;

namespace LevvaCoins.Application.Commands.Interfaces.Category;

public interface IUpdateCategoryHandler : IRequestHandler<UpdateCategoryRequest>
{
}