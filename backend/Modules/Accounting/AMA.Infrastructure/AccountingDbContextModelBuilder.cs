using BuildingBlocks.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace AMA.Infrastructure;

public class AccountingDbContextModelBuilder : IDbContextModelBuilder<AccountingDbContext>
{
    public void EntitiesConfigure(ModelBuilder modelBuilder)
    {
        /* apply all configuration specified in types implementing IEntityTypeConfiguration in a given assembly. */
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AccountingDbContextModelBuilder).Assembly);
    }

    public void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        //configurationBuilder.Properties<DateOnly>()
        //    .HaveConversion<DateOnlyConverter>()
        //    .HaveColumnType("date");
        //configurationBuilder.Properties<TimeOnly>()
        //    .HaveConversion<TimeOnlyConverter>()
        //    .HaveColumnType("time");
    }
}