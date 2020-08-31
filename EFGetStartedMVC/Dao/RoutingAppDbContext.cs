using EFGetStartedMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace EFGetStartedMVC.Dao
{
    // App database context
    public class RoutingAppDbContext : DbContext
    {
        public RoutingAppDbContext(DbContextOptions<RoutingAppDbContext> options) 
            : base(options)
            {

            }

        // Add a DSet (data set)
        public DbSet<BlogPost> BlogPosts {get;set;} 
        
    }
}