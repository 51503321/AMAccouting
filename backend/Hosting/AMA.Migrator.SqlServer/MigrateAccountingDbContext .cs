using AMA.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace AMA.Migrator.SqlServer;

public class MigrateAccountingDbContext : SegregateDbContext<MigrateAccountingDbContext>
{
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // temporarily not use until figure it out what is it purpose
        // khong co nay la khong quet dc cai ientityConfiguration?
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AccountingInfrastructureModule).Assembly);
    }
}
