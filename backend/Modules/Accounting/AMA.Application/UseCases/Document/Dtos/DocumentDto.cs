namespace AMA.Application.UseCases.Document.Dtos;

public class DocumentDto
{
    public Guid Id { get; set; }
    public string DocumentNo { get; set; }
    public DateTime CreatedDate { get; set; }
    public Guid TypeId { get; set; }
    public string Description { get; set; }
    public decimal Sum { get; set; }
}
