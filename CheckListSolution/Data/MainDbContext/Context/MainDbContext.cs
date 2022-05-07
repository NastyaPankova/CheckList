using Microsoft.EntityFrameworkCore;
using DbEntities;

namespace CheckListDbContext.Context
{
    public class MainDbContext : DbContext
    {
        public DbSet<CheckList> CheckLists { get; set; }
        public DbSet<CheckListUser> CheckListUsers { get; set; }
        public DbSet<ListItem> ListItems { get; set; }
        public DbSet<Permision> Permisions { get; set; }
        public DbSet<Status> Statuses { get; set; }

        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)   { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CheckListUser>()
           .HasKey(e => new { e.UserId, e.CheckListId });

            modelBuilder.Entity<Permision>().HasIndex(u => u.Name).IsUnique();

            modelBuilder.Entity<Status>().HasIndex(u => u.Name).IsUnique();
        }

    }
}