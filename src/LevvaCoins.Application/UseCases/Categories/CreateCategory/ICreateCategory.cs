using LevvaCoins.Application.UseCases.Categories.Common;
using MediatR;

namespace LevvaCoins.Application.UseCases.Categories.CreateCategory;
public interface ICreateCategory : IRequestHandler<CreateCategoryInput, CategoryModelOutput>
{
}
