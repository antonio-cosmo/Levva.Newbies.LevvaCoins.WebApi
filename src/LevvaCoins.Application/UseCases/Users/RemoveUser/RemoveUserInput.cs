using MediatR;

namespace LevvaCoins.Application.UseCases.Users.RemoveUser
{
    public class RemoveUserInput : IRequest
    {
        public Guid Id { get; set; }

        public RemoveUserInput(Guid id)
        {
            Id = id;
        }
    }
}
