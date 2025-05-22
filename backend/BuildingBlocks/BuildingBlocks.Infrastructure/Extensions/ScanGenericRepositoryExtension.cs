using Autofac;
using BuildingBlocks.Domain.Repositories;
using System.Reflection;

namespace BuildingBlocks.Infrastructure.Extensions;

public static class ScanGenericRepositoryExtension
{
    public static void ScanGenericRepository(this ContainerBuilder builder, Assembly assembly)
    {
        builder.RegisterAssemblyTypes(assembly).AsClosedTypesOf(typeof(IRepository<,>))
            .AsSelf();
    }
}

