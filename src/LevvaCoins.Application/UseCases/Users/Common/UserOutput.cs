using LevvaCoins.Domain.Entities;

namespace LevvaCoins.Application.UseCases.Users.Common;
public class UserOutput
{
    public Guid Id { get; }
    public string Name { get; }
    public string Email { get; }
    public string? Avatar { get; }

    public UserOutput(Guid id, string name, string email, string? avatar = null)
    {
        Id = id;
        Name = name;
        Email = email;
        Avatar = avatar;
    }

    public static UserOutput FromDomain(User user)
    {
        return new(
                user.Id,
                user.Name,
                user.Email,
                user.Avatar
            );
    }

    public static IEnumerable<UserOutput> FromDomain(IEnumerable<User> users)
    {
        return users.Select(FromDomain);
    }
}
