using LevvaCoins.Domain.Entities;
using MediatR;

namespace LevvaCoins.Application.Accounts.Queries
{
    public class GetAccountByEmailQuery : IRequest<User?>
    {
        public string Email { get; set; }

        public GetAccountByEmailQuery(string email)
        {
            Email = email;
        }
    }
}
