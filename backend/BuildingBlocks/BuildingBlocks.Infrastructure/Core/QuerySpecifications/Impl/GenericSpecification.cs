using System.Linq.Expressions;

namespace BuildingBlocks.Infrastructure.Core.QuerySpecifications.Impl;

public class GenericSpecification<TEntity> : ISpecification<TEntity>
{
    public Expression<Func<TEntity, bool>> Criteria { get; set; }
    public List<Expression<Func<TEntity, object>>> Includes { get; set; } = new List<Expression<Func<TEntity, object>>>();
    public List<string> IncludeStrings { get; set; } = new List<string>();
    public Expression<Func<TEntity, object>> OrderBy { get; set; }
    public Expression<Func<TEntity, object>> OrderByDescending { get; set; }
    public int Take { get; set; }
    public int Skip { get; set; }
    public bool AsNoTracking { get; set; }
    public bool IgnoreQueryFilters { get; set; }

    public GenericSpecification()
    {

    }
}
