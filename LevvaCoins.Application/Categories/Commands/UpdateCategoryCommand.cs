using MediatR;

namespace LevvaCoins.Application.Categories.Commands
{
    public class UpdateCategoryCommand : IRequest
    {
        public string Description { get; set; } = string.Empty;
        public Guid Id { get; set; }

        public UpdateCategoryCommand(string description, Guid id)
        {
            Description = description;
            Id = id;
        }
    }
}
