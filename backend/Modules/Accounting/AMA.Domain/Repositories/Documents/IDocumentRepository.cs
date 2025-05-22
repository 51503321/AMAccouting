using AMA.Domain.Entities;
using BuildingBlocks.Domain.Repositories;

namespace AMA.Domain.Repositories.Documents;

public interface IDocumentRepository : IRepository<Document, Guid>
{

}

