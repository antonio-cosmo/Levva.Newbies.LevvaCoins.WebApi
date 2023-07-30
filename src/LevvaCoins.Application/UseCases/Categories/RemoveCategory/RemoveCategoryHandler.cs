using LevvaCoins.Application.Services.Interfaces;

namespace LevvaCoins.Application.UseCases.Categories.RemoveCategory
{
    public class RemoveCategoryHandler : IRemoveCategoryHandler
    {
        private readonly ICategoryServices _categoryServices;

        public RemoveCategoryHandler(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        public async Task Handle(RemoveCategory request, CancellationToken cancellationToken)
        {
            await _categoryServices.Removeasync(request.Id, cancellationToken);
        }
    }
}
