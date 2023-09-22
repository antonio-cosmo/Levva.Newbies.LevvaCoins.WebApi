using LevvaCoins.Application.Queries.Requests.Category;
using LevvaCoins.Application.Responses;
using MediatR;

namespace LevvaCoins.Application.Queries.Interfaces.Category;

public interface IGetAllCategoryHandler : IRequestHandler<GetAllCategoryRequest, IEnumerable<CategoryModelResponse>>
{
}