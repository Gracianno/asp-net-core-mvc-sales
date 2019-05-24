using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Sales_mvc.Models
{
    public class Sales_mvcContext : DbContext
    {
        public Sales_mvcContext (DbContextOptions<Sales_mvcContext> options)
            : base(options)
        {
        }

        public DbSet<Sales_mvc.Models.Department> Department { get; set; }
    }
}
