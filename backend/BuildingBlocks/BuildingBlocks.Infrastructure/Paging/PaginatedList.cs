namespace BuildingBlocks.Infrastructure.Paging;

public class PaginatedList<T>(List<T> items, int totalCount, int offset, int limit) where T : class
{
    public List<T> Items { get; } = items;
    public int TotalCount { get; } = totalCount;
    public int Offset { get; } = offset;
    public int Limit { get; } = limit;
    public int TotalPages { get; } = (int)Math.Ceiling(totalCount / (double)limit);
}

