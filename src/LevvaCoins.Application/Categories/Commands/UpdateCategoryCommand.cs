using MediatR;

namespace LevvaCoins.Application.Categories.Commands
{
    public class UpdateCategoryCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Description { get; set; }

        public UpdateCategoryCommand(Guid id, string description)
        {
            Id = id;
            Description = description;
        }
    }
}
