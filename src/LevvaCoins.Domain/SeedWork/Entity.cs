namespace LevvaCoins.Domain.SeedWork;
public abstract class Entity
{
    public Guid Id { get; }
    protected Entity()
    {
        Id = Guid.NewGuid();
    }
}
