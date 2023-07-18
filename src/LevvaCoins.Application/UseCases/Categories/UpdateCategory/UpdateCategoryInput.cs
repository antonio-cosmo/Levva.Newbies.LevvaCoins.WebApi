using MediatR;

namespace LevvaCoins.Application.UseCases.Categories.UpdateCategory
{
    public class UpdateCategoryInput : IRequest
    {
        public Guid Id { get; set; }
        public string Description { get; set; }

        public UpdateCategoryInput(Guid id, string description)
        {
            Id = id;
            Description = description;
        }
    }
}
