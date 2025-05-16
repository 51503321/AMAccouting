using AMA.Migrator.SqlServer;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Data.Common;

internal class Program
{
    private static async Task<int> Main(string[] args)
    {
        try
        {
            var builder = WebApplication.CreateBuilder(args);
            var rootConfiguration = builder.Configuration;

            #region DbContext

            builder.Services.AddDbContext<MigrateAccountingDbContext>(opt =>
            {
                opt.UseSqlServer(
                    rootConfiguration.GetConnectionString("Default"),
                    b => b.MigrationsAssembly(typeof(Program).Assembly.FullName)
                        .MigrationsHistoryTable("__AccountingMigrationsHistory", "AM")
                );
            });

            #endregion

            var app = builder.Build();
            using var serviceScope = app.Services.CreateScope();
            var migrateAccountingDbContext = serviceScope.ServiceProvider.GetRequiredService<MigrateAccountingDbContext>();
            var listDbContext = new List<DbContext>
            {
                migrateAccountingDbContext
            };
            foreach (var dbContext in listDbContext)
            {
                var pendingMigrations = (await dbContext.Database.GetPendingMigrationsAsync()).ToList();
                if (pendingMigrations.Any())
                {
                    await dbContext.Database.MigrateAsync();
                }
            }

            return 0;
        }
        catch (Exception ex)
        {
            return 0;
        }
    }
}