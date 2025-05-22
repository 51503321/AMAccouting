namespace BuildingBlocks.Domain.Entities;

public interface IEntity<TEntity>
{
    public TEntity Id { get; set; }
}