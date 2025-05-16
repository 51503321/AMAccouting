namespace AMA.Domain.Entities;

public class Document
{
    public Guid Id { get; set; }
    public string DocumentNo { get; set; }
    public DateTime CreatedDate { get; set; }
    public Guid TypeId { get; set; }
    public MasterData Type { get; set; }
    public string Description { get; set; }
    public decimal Sum { get; set; }
    public ICollection<DocumentDetail> DocumentDetails { get; } = new List<DocumentDetail>();
}
