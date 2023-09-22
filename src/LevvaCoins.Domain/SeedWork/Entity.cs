using LevvaCoins.Domain.SeedWork.Notification;

namespace LevvaCoins.Domain.SeedWork;
public abstract class Entity : Notifiable
{
    public Guid Id { get; }
    protected abstract void Validate();
    protected Entity()
    {
        Id = Guid.NewGuid();
    }
}
