using AMA.Shared.Abstractions.Commands.Commands;

namespace AMA.Application.UseCases.Base;

public abstract class BaseCommandHandler<TCommand> : ICommandHandler<TCommand> where TCommand : class, ICommand
{
    public virtual async Task HandleAsync(TCommand command)
    {
        await Task.CompletedTask;
    }

    /* https://autofac.readthedocs.io/en/latest/advanced/circular-dependencies.html
     * 
     * When DIContainer resolves ICommandHandler<CreateDocumentCommand>, it need to create CreateDocumentHandler.
     (it relevants to the definition when DIContainer registers, instance of service being created).
     * CreateDocumentHandler inherits from BaseCommandHandler and BaseCommandHandler is registered as a decorator for ICommandHandler<TCommand>
     as a constructor parameter, so at the same time it also needs to resolve ICommandHandler<CreateDocumentCommand>.
     * This creates a circular dependency.
     
     private readonly ICommandHandler<TCommand> _decoratedHandler;
     public BaseCommandHandler(ICommandHandler<TCommand> decoratedHandler)
     {
         _decoratedHandler = decoratedHandler ?? throw new ArgumentNullException(nameof(decoratedHandler));
     }
     public virtual async Task HandleAsync(TCommand command)
     {
         await _decoratedHandler.HandleAsync(command);
     }
     */
}
