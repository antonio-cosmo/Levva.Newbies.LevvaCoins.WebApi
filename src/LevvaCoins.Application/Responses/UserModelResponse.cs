using DomainEntity = LevvaCoins.Domain.Entities;

namespace LevvaCoins.Application.Responses;

public class UserModelResponse
{
    public UserModelResponse(Guid id, string name, string email, string? avatar = null)
    {
        Id = id;
        Name = name;
        Email = email;
        Avatar = avatar;
    }

    public Guid Id { get; }
    public string Name { get; }
    public string Email { get; }
    public string? Avatar { get; }

    public static UserModelResponse FromDomain(DomainEntity.User user)
    {
        return new UserModelResponse(
            user.Id,
            user.Name,
            user.Email,
            user.Avatar
        );
    }

    public static IEnumerable<UserModelResponse> FromDomain(IEnumerable<DomainEntity.User> users)
    {
        return users.Select(FromDomain);
    }
}