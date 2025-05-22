using Autofac;
using BuildingBlocks.Infrastructure.Extensions;

namespace AMA.Infrastructure;

/* 
 * Register generic repository, AccountingInfrastructureModule is a part of autofac
 */

public class AccountingInfrastructureModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        var thisAssembly = GetType().Assembly;
        builder.ScanGenericRepository(thisAssembly);
        base.Load(builder);
    }
}
