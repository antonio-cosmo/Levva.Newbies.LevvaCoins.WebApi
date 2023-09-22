using MediatR;

namespace LevvaCoins.Application.Commands.Requests.Category;

public class RemoveCategoryRequest : IRequest
{
    public RemoveCategoryRequest(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}