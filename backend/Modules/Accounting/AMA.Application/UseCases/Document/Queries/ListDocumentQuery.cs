using AMA.Application.UseCases.Document.Dtos;
using MediatR;

namespace AMA.Application.UseCases.Document.Queries;

public class ListDocumentQuery : IRequest<List<DocumentDto>>
{
    public int PageIndex { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
