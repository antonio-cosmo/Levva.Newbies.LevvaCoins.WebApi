using LevvaCoins.Application.Services.Dtos.Category;
using MediatR;

namespace LevvaCoins.Application.UseCases.Categories.CreateCategory;
public interface ICreateCategoryHandler : IRequestHandler<CreateCategory, CategoryModelResponse>
{
}
