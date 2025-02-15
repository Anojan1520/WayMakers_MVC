using ECommerce.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Web.Database
{
    public class ApplicationDbContext : DbContext
    {
        private readonly ApplicationDbContext _DbContext;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> Options) : base(Options)
        {
            
        }
        public DbSet<Product> Products { get; set; }

    }
}
