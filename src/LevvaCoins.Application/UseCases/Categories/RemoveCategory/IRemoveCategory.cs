using MediatR;

namespace LevvaCoins.Application.UseCases.Categories.RemoveCategory;
public interface IRemoveCategory : IRequestHandler<RemoveCategoryInput>
{
}
