using LevvaCoins.Domain.Entities;
using MediatR;

namespace LevvaCoins.Application.Users.Queries
{
    public class GetUserByIdQuery : IRequest<User?>
    {
        public Guid Id { get; set; }

        public GetUserByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
