using LevvaCoins.Domain.Entities;
using MediatR;

namespace LevvaCoins.Application.UseCases.Users.Queries
{
    public class GetUserByEmailQuery : IRequest<User?>
    {
        public string Email { get; set; }

        public GetUserByEmailQuery(string email)
        {
            Email = email;
        }
    }
}
