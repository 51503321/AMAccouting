using AMA.Application.UseCases.Document.Commands;
using AMA.Shared.Abstractions.Commands.Commands;
using Microsoft.AspNetCore.Mvc;

namespace AMA.Endpoints.Controllers;

[Route("/api/am/test")]
public class TestController : BaseController
{
    private readonly ICommandHandler<CreateDocumentCommand> _commandHandler;

    public TestController(ICommandHandler<CreateDocumentCommand> commandHandler)
    {
        _commandHandler = commandHandler;
    }

    [HttpGet("contravariant")]
    public async Task<ActionResult<object>> Get()
    {
        //await _commandHandler.HandleAsync(new CreateDocumentCommand());

        //BaseCommandHandler baseCommandHandler = new();
        //await baseCommandHandler.HandleAsync(new DerrivedCommand()); // BaseCommandHandler
        //await baseCommandHandler.HandleAsync(new BaseCommand()); // BaseCommandHandler
        //ICommandHandler<DerrivedCommand> derivedHandler = baseCommandHandler;
        //await derivedHandler.HandleAsync(new DerrivedCommand()); // BaseCommandHandler
        return OkOrNotFound(string.Empty);
    }
}
