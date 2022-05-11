using Microsoft.EntityFrameworkCore;
using DbEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace CheckListDbContext.Context
{
    public class MainDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public DbSet<CheckList> CheckLists { get; set; }
        public DbSet<CheckListUser> CheckListUsers { get; set; }
        public DbSet<ListItem> ListItems { get; set; }
        public DbSet<Permision> Permisions { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<User> Users { get; set; }

        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)   { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CheckListUser>()
           .HasKey(e => new { e.UserId, e.CheckListId });

            modelBuilder.Entity<Permision>().HasIndex(u => u.Name).IsUnique();

            modelBuilder.Entity<Status>().HasIndex(u => u.Name).IsUnique();

            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();

            base.OnModelCreating(modelBuilder);
        }

    }
}