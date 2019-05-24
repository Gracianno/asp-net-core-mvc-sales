
using Microsoft.EntityFrameworkCore;

namespace Sales_mvc.Models
{
    public class Sales_mvcContext : DbContext
    {
        public Sales_mvcContext (DbContextOptions<Sales_mvcContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<SalesRecord> SalesRecords { get; set; }
    }
}
