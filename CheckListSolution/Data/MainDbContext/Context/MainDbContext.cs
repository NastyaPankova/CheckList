using Microsoft.EntityFrameworkCore;

namespace CheckListDbContext.Context
{
    public class MainDbContext : DbContext
    {
       public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)   { }
              
    }
}