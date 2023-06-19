using LevvaCoins.Domain.Entities;
using MediatR;

namespace LevvaCoins.Application.Users.Queries
{
    public class GetAllUserQuery : IRequest<IEnumerable<User>>
    {
    }
}
