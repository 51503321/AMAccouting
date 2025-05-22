using BuildingBlocks.Domain.Entities;

namespace AMA.Domain.Entities;

public class DocumentDetail : AuditedEntity<Guid>
{
    public string AccountNo { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public Guid TransactionTypeId { get; set; }
    public MasterData TransactionType { get; set; }
    public Guid DocumentId { get; set; }
    public Document Document { get; set; }
}
