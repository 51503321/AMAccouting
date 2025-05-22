namespace BuildingBlocks.Infrastructure.Paging;

public class PaginatedListQuery
{
    public int Offset { get; set; }
    public int Limit { get; set; }
    public PaginatedListQuery()
    {
        Offset = 0;
        Limit = 10;
    }
    public PaginatedListQuery(int offset, int limit)
    {
        Offset = offset;
        Limit = limit;
    }
}
