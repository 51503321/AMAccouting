using AMA.Domain.Entities;
using BuildingBlocks.Domain.Repositories;

namespace AMA.Domain.Repositories.Documents;

public interface IMasterDataRepository : IRepository<MasterData, Guid>
{

}
