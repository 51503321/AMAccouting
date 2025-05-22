using BuildingBlocks.Domain.Entities;

namespace AMA.Domain.Entities;

public class MasterData : AuditedEntity<Guid>
{
    public string Code { get; set; }
    public string Name { get; set; }
    public bool? Used { get; set; }
    public int? Rank { get; set; }
    public string Note { get; set; }
}
