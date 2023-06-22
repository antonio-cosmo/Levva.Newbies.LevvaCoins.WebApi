namespace LevvaCoins.Domain.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; }
        public abstract bool IsValid();
    }
}
