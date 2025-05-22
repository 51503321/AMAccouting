using BuildingBlocks.Infrastructure.Paging;

namespace BuildingBlocks.Infrastructure.Core.QuerySpecifications;

public interface IQueryPaginated
{
    public PaginatedListQuery PaginatedListQuery { get; set; }
}
