using MediatR;

namespace LevvaCoins.Application.UseCases.Categories.UpdateCategory;

public interface IUpdateCategory : IRequestHandler<UpdateCategoryInput>
{
}
