namespace BuildingBlocks.Domain.Entities;

public abstract class AuditedEntity<TKey>
{
    public TKey Id { get; set; }
    public virtual DateTime CreationTime { get; set; }
    public virtual TKey? CreatorUserId { get; set; }
    public virtual DateTime? LastModificationTime { get; set; }
    public virtual TKey? LastModifierUserId { get; set; }
}

/* 
 * An abstract class cannot be instantiated directly.
 * Represent a concept: It's a blueprint for entities that have audit properties, not a thing itself.
 * When Entity inherits from AuditedEntity<Guid>, it clearly signifies that this Entity has auditing characteristics.
 */