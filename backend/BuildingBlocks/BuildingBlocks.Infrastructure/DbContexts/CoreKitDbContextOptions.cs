using Microsoft.EntityFrameworkCore;

namespace BuildingBlocks.Infrastructure.DbContexts;

public class CoreKitDbContextOptions
{
    public Action<DbContextOptionsBuilder> ConfigureAction { get; private set; }

    public CoreKitDbContextOptions()
    {
        // Initialize with a default empty action to prevent NullReferenceException
        ConfigureAction = builder => { };
    }

    public void Configure(Action<DbContextOptionsBuilder> configureAction)
    {
        ConfigureAction = configureAction ?? throw new ArgumentNullException(nameof(configureAction));
    }
}
