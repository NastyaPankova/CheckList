using Microsoft.EntityFrameworkCore;
using CheckListDbContext.Context;

namespace CheckListDbContext.Factories;

public class MainDbContextFactory
{
    private readonly DbContextOptions<MainDbContext> options;

    public MainDbContextFactory(DbContextOptions<MainDbContext> options)
    {
        this.options = options;
    }

    public MainDbContext Create()
    {
        return new MainDbContext(options);
    }
}