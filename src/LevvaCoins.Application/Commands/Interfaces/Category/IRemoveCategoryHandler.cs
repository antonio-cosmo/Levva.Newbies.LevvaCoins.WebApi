using LevvaCoins.Application.Commands.Requests.Category;
using MediatR;

namespace LevvaCoins.Application.Commands.Interfaces.Category;

public interface IRemoveCategoryHandler : IRequestHandler<RemoveCategoryRequest>
{
}