using AMA.Application;
using AMA.Application.UseCases.Base;
using AMA.Application.UseCases.Document.Commands;
using AMA.Application.UseCases.Document.Commands.Handlers;
using AMA.Infrastructure;
using AMA.Shared.Abstractions.Commands.Commands;
using Autofac;
using BuildingBlocks.Infrastructure.DbContexts;

namespace AMA.WebApp;

public class Startup
{
    private readonly IHostEnvironment _env;

    public IConfiguration Configuration { get; }
    
    public Startup(IConfiguration configuration, IHostEnvironment env)
    {
        Configuration = configuration;
        _env = env;
    }

    /* 
     * Run second
     * This is the default if you don't have an environment specific method.
     * Using a custom DI container.
     * 
     */
    public void ConfigureContainer(ContainerBuilder builder)
    {
        builder.RegisterModule<AccountingInfrastructureModule>();

        builder.RegisterModule<CommandHandlerApplicationModule>();

        // dem cho khac
        builder.RegisterGenericDecorator(
             typeof(LoggingCommandHandler<>),
             typeof(ICommandHandler<>));
    }

    /*
     * Run first
     * ConfigureServices is optional.
     * This method gets called by the runtime.
     * Called by the host before the Configure method to configure the app's services.
     * Adding services to the service container makes them available within the app and in the Configure method.
     * This method gets called by the runtime. Use this method to add services to the container.
     * Is where you register dependencies and return an `IServiceProvider` implemented by `AutofacServiceProvider`
     */
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc(opt => { opt.EnableEndpointRouting = false; });

        // why this is AddTransient but not scoped?????
        //services.AddTransient<IDbContextModelBuilder<AccountingDbContext>, AccountingDbContextModelBuilder>();

        // interface, abstract class can't be registered by type
        //services.AddTransient<ICommandHandler<CreateDocumentCommand>, BaseCommandHandler<CreateDocumentCommand>>();

        //services.Configure<CoreKitDbContextOptions>(options =>
        //{
        //    options.Configure(builder =>
        //    {
        //        builder
        //            .UseSqlServer(Configuration.GetConnectionString("Default") ?? string.Empty)
        //            .LogTo(Console.WriteLine, LogLevel.Error);
        //    });
        //});
    }

    /* 
     * Run third
     * This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
     * Is where you add middleware.
     */
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
