using System.Reflection.Metadata;
using BlogApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Repositories
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {
        }
        
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().ToTable("posts");
            modelBuilder.Entity<User>().ToTable("users");
        }
    }
}