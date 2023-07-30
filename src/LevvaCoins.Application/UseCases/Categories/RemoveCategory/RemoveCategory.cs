using MediatR;

namespace LevvaCoins.Application.UseCases.Categories.RemoveCategory
{
    public class RemoveCategory : IRequest
    {
        public Guid Id { get; set; }

        public RemoveCategory(Guid id)
        {
            Id = id;
        }
    }
}
