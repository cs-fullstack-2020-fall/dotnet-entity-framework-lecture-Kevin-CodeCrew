using System;
using Microsoft.EntityFrameworkCore;

namespace EFGetStarted
{
    // Db context to interact with posts in the database
    class BloggingContext : DbContext
    {
        public DbSet<Post> Posts {get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=blogging.db");

    }

    // Simple model for blog posts
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Comment { get; set; }
    }
}