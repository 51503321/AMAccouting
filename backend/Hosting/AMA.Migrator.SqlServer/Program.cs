using AMA.Migrator.SqlServer;
using Autofac.Core;
using BuildingBlocks.Infrastructure.DbContexts;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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

            // tai sao co nay
            builder.Services.AddDbContext<MigrateAccountingDbContext>(opt =>
            {
                opt.UseSqlServer(
                    rootConfiguration.GetConnectionString("Default"),
                    b => b.MigrationsAssembly(typeof(Program).Assembly.FullName)
                        .MigrationsHistoryTable("__AccountingMigrationsHistory", "AM")
                );
            });

            // ma lai vua co cai nay
            builder.Services.Configure<CoreKitDbContextOptions>(options =>
            {
                options.Configure(builder =>
                {
                    builder
                        .UseSqlServer(rootConfiguration.GetConnectionString("Default") ?? string.Empty)
                        .LogTo(Console.WriteLine, LogLevel.Error);
                });
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