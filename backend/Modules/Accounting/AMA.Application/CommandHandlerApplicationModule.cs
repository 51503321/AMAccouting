using AMA.Shared.Abstractions.Commands.Commands;
using Autofac;

namespace AMA.Application;

public class CommandHandlerApplicationModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        var thisAssembly = GetType().Assembly;
        builder.RegisterAssemblyTypes(thisAssembly)
            .AsClosedTypesOf(typeof(ICommandHandler<>))
            .AsImplementedInterfaces();
        base.Load(builder);
    }
}
