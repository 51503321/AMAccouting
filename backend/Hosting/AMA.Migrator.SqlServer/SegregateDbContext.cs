using BuildingBlocks.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace AMA.Migrator.SqlServer;

public abstract class SegregateDbContext<T> : CoreKitDbContext<T> where T : DbContext
{
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        //base.ConfigureConventions(configurationBuilder);
        //configurationBuilder.Properties<Status>().HaveConversion<StatusConverter>()
        //    .HaveMaxLength(10);
        //configurationBuilder.Properties<Gender>().HaveConversion<GenderValueConverter>()
        //    .HaveMaxLength(10);
        //configurationBuilder.Properties<WorkflowAction>().HaveConversion<WorkflowActionConverter>()
        //    .HaveMaxLength(20);
        //configurationBuilder.Properties<decimal>().HavePrecision(18, 2);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        #region ExcludeFromMigrations specific class that used common

        //modelBuilder.Entity<RootCatalogue>().ToTable(nameof(RootCatalogue), CatalogConfigureEntities.SchemaName,
        //    t => t.ExcludeFromMigrations());

        //modelBuilder.Entity<Catalogue>().ToTable(nameof(Catalogue), CatalogConfigureEntities.SchemaName,
        //    t => t.ExcludeFromMigrations());
        //modelBuilder.Entity<Country>().ToTable(nameof(Country), CatalogConfigureEntities.SchemaName,
        //t => t.ExcludeFromMigrations());

        //modelBuilder.Entity<Province>().ToTable(nameof(Province), CatalogConfigureEntities.SchemaName,
        //    t => t.ExcludeFromMigrations());

        //modelBuilder.Entity<District>().ToTable(nameof(District), CatalogConfigureEntities.SchemaName,
        //    t => t.ExcludeFromMigrations());

        //modelBuilder.Entity<JobTitle>().ToTable(nameof(JobTitle), CatalogConfigureEntities.SchemaName,
        //    t => t.ExcludeFromMigrations());

        //modelBuilder.Entity<JobTitleGroup>().ToTable(nameof(JobTitleGroup), CatalogConfigureEntities.SchemaName,
        //    t => t.ExcludeFromMigrations());

        //modelBuilder.Entity<Ward>().ToTable(nameof(Ward), CatalogConfigureEntities.SchemaName,
        //    t => t.ExcludeFromMigrations());

        //modelBuilder.Entity<CatalogueProfile>().ToTable(nameof(CatalogueProfile), CatalogConfigureEntities.SchemaName,
        //    t => t.ExcludeFromMigrations());

        //modelBuilder.Ignore<WeightOrder>();
        //modelBuilder.Entity<FileEntryCollection>().ToTable(t => t.ExcludeFromMigrations());
        //modelBuilder.Entity<FileEntry>().ToTable(t => t.ExcludeFromMigrations());
        //modelBuilder.Entity<FileEntryUploadProcess>().ToTable(t => t.ExcludeFromMigrations());

        #endregion

        #region Ignore configuration of CoreHR

        //modelBuilder.ConfigureCoreIdentityEntities(false); way to check if it need to include in migrations or not

        #endregion
    }
}