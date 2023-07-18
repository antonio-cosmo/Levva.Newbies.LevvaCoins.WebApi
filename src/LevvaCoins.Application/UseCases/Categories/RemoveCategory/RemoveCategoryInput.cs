using MediatR;

namespace LevvaCoins.Application.UseCases.Categories.RemoveCategory
{
    public class RemoveCategoryInput : IRequest
    {
        public Guid Id { get; set; }

        public RemoveCategoryInput(Guid id)
        {
            Id = id;
        }
    }
}
