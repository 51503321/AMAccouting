using AMA.Domain.Entities;
using AMA.Domain.Repositories.Documents;
using BuildingBlocks.Infrastructure.DbContexts;
using BuildingBlocks.Infrastructure.Repositories;

namespace AMA.Infrastructure.Repositories.Documents;

public class MasterDataRepository : EfRepository<AccountingDbContext, MasterData, Guid>, IMasterDataRepository
{
    public MasterDataRepository(IDbContextProvider<AccountingDbContext> dbContextProvider) : base(dbContextProvider)
    {

    }
}