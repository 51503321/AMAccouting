namespace AMA.Domain.Entities;

public class MasterData
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public bool? Used { get; set; }
    public int? Rank { get; set; }
    public string Note { get; set; }
}
