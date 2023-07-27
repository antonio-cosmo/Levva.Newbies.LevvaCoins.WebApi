using LevvaCoins.Application.Exceptions;
using LevvaCoins.Application.UseCases.Users.Common;
using LevvaCoins.Domain.SeedWork;

namespace LevvaCoins.Application.UseCases.Users.GetUser
{
    public class GetUser : IGetUser
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUser(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UserModelOutput?> Handle(GetUserInput request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetAsync(request.Id, cancellationToken)
                ?? throw new ModelNotFoundException("Esse usuário não existe.");
            return UserModelOutput.FromDomain(user);
        }
    }
}
