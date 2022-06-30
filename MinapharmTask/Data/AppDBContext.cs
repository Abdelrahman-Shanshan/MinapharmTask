using Microsoft.EntityFrameworkCore;
using MinapharmTask.Models;

namespace MinapharmTask.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        public DbSet<AssetsAttributes> AssetsAttributes { get; set; }
    }
}
