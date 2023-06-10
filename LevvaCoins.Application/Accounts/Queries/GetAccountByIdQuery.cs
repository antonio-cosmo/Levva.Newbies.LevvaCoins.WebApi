using LevvaCoins.Domain.Entities;
using MediatR;

namespace LevvaCoins.Application.Accounts.Queries
{
    public class GetAccountByIdQuery : IRequest<User?>
    {
        public Guid Id { get; set; }

        public GetAccountByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
