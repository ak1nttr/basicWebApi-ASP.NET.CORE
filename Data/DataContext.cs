using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApi_01.Entities;


namespace WebApi_01.Data
{
    public class DataContext : IdentityDbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            


        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<User> Users { get; set; }  
        public DbSet<Food> Foods { get; set; }
        public DbSet<Post> Posts { get; set; }  
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }

       




    }
}
