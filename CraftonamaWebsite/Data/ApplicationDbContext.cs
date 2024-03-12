using CraftonamaWebsite.Models;
using Microsoft.EntityFrameworkCore;

namespace CraftonamaWebsite.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options) 
        {
            
        }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Small Albums", DisplayOrder = 1 },
                new Category { CategoryId = 2, Name = "Vinatage Photo Frames", DisplayOrder = 2 });
        }
    }
}
