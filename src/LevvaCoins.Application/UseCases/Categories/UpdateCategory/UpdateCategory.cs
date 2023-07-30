using MediatR;

namespace LevvaCoins.Application.UseCases.Categories.UpdateCategory
{
    public class UpdateCategory : IRequest
    {
        public Guid Id { get; set; }
        public string Description { get; set; }

        public UpdateCategory(Guid id, string description)
        {
            Id = id;
            Description = description;
        }
    }
}
