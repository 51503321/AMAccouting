using System.Linq.Expressions;

namespace BuildingBlocks.Infrastructure.Core.QuerySpecifications;

public interface ISpecification<TEntity>
{
    Expression<Func<TEntity, bool>> Criteria { get; }
    List<Expression<Func<TEntity, object>>> Includes { get; }
    List<string> IncludeStrings { get; }
    Expression<Func<TEntity, object>> OrderBy { get; }
    Expression<Func<TEntity, object>> OrderByDescending { get; }
    int Take { get; }
    int Skip { get; }
    bool AsNoTracking { get; }
    bool IgnoreQueryFilters { get; }
}