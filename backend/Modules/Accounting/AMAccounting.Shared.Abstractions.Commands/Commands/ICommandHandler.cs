namespace AMA.Shared.Abstractions.Commands.Commands;

/* 
 * The in keyword -> contravariance.
 * The in keyword is allowed because TCommand is only used in input positions(as a parameter to HandleAsync).
If TCommand were used as a return type or an output parameter, in keyword would not be allowed.
 *  If TCommand is contravariance, it means you can use a less derived type(more specified or because it's base class so it less derived)
than specified by the generic parameter.
 * 
 * Benefits:
 * Increased Flexibility in DI/IoC Containers:
 * You can register a more general handler(ICommandHandler<BaseCommand>) and have it automatically resolved 
when a more specific type(ICommandHandler<SpecificCommand>) is requested.
*/

public interface ICommandHandler<in TCommand> where TCommand : class, ICommand
{
    Task HandleAsync(TCommand command);
}

