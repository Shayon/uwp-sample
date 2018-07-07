using DatabaseSampleApp.DB.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseSampleApp.DB.Context
{
    public class BloggingContext : DbContext
    {
        public DbSet<Website> Websites { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Blogging.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            if (UseInpc)
            {
                modelBuilder.HasChangeTrackingStrategy(ChangeTrackingStrategy.ChangingAndChangedNotifications);
            }
        }

        private const bool UseInpc = true;
    }
}
