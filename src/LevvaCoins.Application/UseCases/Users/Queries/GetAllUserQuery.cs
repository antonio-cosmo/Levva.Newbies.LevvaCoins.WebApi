using LevvaCoins.Domain.Entities;
using MediatR;

namespace LevvaCoins.Application.UseCases.Users.Queries
{
    public class GetAllUserQuery : IRequest<IEnumerable<User>>
    {
    }
}
