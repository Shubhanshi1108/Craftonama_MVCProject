using Craftonama_Razor.Models;
using Microsoft.EntityFrameworkCore;

namespace Craftonama_Razor.Data
{
	public class RazorApplicationDbContext : DbContext
	{
        public RazorApplicationDbContext(DbContextOptions<RazorApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
    }
}
