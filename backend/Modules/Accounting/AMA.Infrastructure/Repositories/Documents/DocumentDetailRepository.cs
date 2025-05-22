using AMA.Domain.Entities;
using AMA.Domain.Repositories.Documents;
using BuildingBlocks.Infrastructure.DbContexts;
using BuildingBlocks.Infrastructure.Repositories;

namespace AMA.Infrastructure.Repositories.Documents;

public class DocumentDetailRepository : EfRepository<AccountingDbContext, DocumentDetail, Guid>, IDocumentDetailRepository
{
    public DocumentDetailRepository(IDbContextProvider<AccountingDbContext> dbContextProvider) : base(dbContextProvider)
    {

    }
}
