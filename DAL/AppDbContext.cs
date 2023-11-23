using Microsoft.EntityFrameworkCore;
using Pustok_Crud2.Models;

namespace Pustok_Crud2.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options) 
        {
            
        }
        public DbSet<Feature>Features { get; set; }
    }
}
