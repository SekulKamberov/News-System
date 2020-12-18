namespace NewsSystem.Domain.Common.Models
{
    public abstract class Entity<TId>
    {
        public TId Id { get; private set; }
    }
}
