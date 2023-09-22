using MediatR;

namespace LevvaCoins.Application.Commands.Requests.Category;

public class UpdateCategoryRequest : IRequest
{
    public UpdateCategoryRequest(Guid id, string description)
    {
        Id = id;
        Description = description;
    }

    public Guid Id { get; set; }
    public string Description { get; set; }
}