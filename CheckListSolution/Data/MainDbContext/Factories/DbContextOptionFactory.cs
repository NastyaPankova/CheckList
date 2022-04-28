namespace CheckListDbContext.Factories;

using CheckListDbContext.Context;
using Microsoft.EntityFrameworkCore;

public class DbContextOptionFactory
{
    public static DbContextOptions<MainDbContext> Create(string connectionString)
    {
        var builder = new DbContextOptionsBuilder<MainDbContext>();
        Configure(connectionString).Invoke(builder);
        return builder.Options;
    }

    public static Action<DbContextOptionsBuilder> Configure(string connectionString)
    {
        return (builder) => builder.UseSqlServer(connectionString, opt =>
        {
            // CHANGED:10 - too long time
            opt.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds);
        });
    }
}