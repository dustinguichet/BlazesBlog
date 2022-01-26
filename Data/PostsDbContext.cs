using Microsoft.EntityFrameworkCore;
using BlazeBlog.Models;

namespace BlazeBlog.Data
{
    public class PostsDbContext : DbContext
    {
        public PostsDbContext(DbContextOptions<PostsDbContext> options)
            : base(options)
        {
        }
        public DbSet<Post> Posts { get; set; } = null!;
    }
}