using LevvaCoins.Application.Commands.Responses;
using MediatR;

namespace LevvaCoins.Application.UseCases.Categories.CreateCategory;
public interface ICreateCategoryHandler : IRequestHandler<CreateCategory, CategoryModelResponse>
{
}
