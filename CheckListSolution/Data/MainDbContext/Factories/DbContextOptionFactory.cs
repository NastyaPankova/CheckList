using CheckListDbContext.Context;
using Microsoft.EntityFrameworkCore;

namespace CheckListDbContext.Factories;
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
            opt.CommandTimeout((int)TimeSpan.FromMinutes(5).TotalSeconds);
        });
    }
}
