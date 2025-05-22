using AMA.Application.UseCases.Base;

namespace AMA.Application.UseCases.Document.Commands.Handlers;

public sealed class CreateDocumentHandler : BaseCommandHandler<CreateDocumentCommand>
{
    public override async Task HandleAsync(CreateDocumentCommand command)
    {
        await Task.CompletedTask;
    }
}