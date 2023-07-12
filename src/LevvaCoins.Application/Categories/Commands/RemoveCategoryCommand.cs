using MediatR;

namespace LevvaCoins.Application.Categories.Commands
{
    public class RemoveCategoryCommand : IRequest
    {
        public Guid Id { get; set; }

        public RemoveCategoryCommand(Guid id)
        {
            Id = id;
        }
    }
}
