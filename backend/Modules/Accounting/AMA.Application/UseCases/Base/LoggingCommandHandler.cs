using AMA.Shared.Abstractions.Commands.Commands;

namespace AMA.Application.UseCases.Base;

public class LoggingCommandHandler<TCommand> : ICommandHandler<TCommand> where TCommand : class, ICommand
{
    private readonly ICommandHandler<TCommand> _decoratedHandler;

    public LoggingCommandHandler(ICommandHandler<TCommand> decoratedHandler)
    {
        _decoratedHandler = decoratedHandler ?? throw new ArgumentNullException(nameof(decoratedHandler));
    }

    public async Task DoStuff()
    {
        await Task.CompletedTask;
    }

    public async Task HandleAsync(TCommand command)
    {
        await DoStuff();
        await _decoratedHandler.HandleAsync(command);
    }
}