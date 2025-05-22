using AMA.Domain.Entities;
using AMA.Domain.Repositories.Documents;
using BuildingBlocks.Infrastructure.DbContexts;
using BuildingBlocks.Infrastructure.Repositories;

namespace AMA.Infrastructure.Repositories.Documents;

public class DocumentRepository : EfRepository<AccountingDbContext, Document, Guid>, IDocumentRepository
{
    public DocumentRepository(IDbContextProvider<AccountingDbContext> dbContextProvider) : base(dbContextProvider)
    {

    }
}
