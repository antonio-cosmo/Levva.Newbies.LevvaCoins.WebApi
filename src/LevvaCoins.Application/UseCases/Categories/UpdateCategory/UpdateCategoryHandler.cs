using LevvaCoins.Application.Services.Dtos.Category;
using LevvaCoins.Application.Services.Interfaces;

namespace LevvaCoins.Application.UseCases.Categories.UpdateCategory
{
    public class UpdateCategoryHandler : IUpdateCategoryHandler
    {
        private readonly ICategoryServices _categoryServices;
        public UpdateCategoryHandler(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        public async Task Handle(UpdateCategory request, CancellationToken cancellationToken)
        {
            var updateRequest = new UpdateCategoryRequest(request.Id, request.Description);
            await _categoryServices.Updateasync(updateRequest, cancellationToken);
        }
    }
}
