using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.Domain;

namespace WebApplication1.Data
{
    public class ZooDbContext : DbContext
    {
        public ZooDbContext(DbContextOptions options) : base(options) 
        
        {
            
        }

        public DbSet<ZooModel> Animal { get; set; }
    }
}
