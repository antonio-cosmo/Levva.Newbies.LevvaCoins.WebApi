using LevvaCoins.Domain.Entities;
using MediatR;

namespace LevvaCoins.Application.Accounts.Queries
{
    public class GetAllAccountQuery : IRequest<IEnumerable<User>>
    {
    }
}
