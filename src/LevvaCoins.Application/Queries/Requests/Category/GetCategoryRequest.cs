using LevvaCoins.Application.Responses;
using MediatR;

namespace LevvaCoins.Application.Queries.Requests.Category;

public class GetCategoryRequest : IRequest<CategoryModelResponse>
{
    public GetCategoryRequest(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}