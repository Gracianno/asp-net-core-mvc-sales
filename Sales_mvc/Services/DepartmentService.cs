using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sales_mvc.Models;

namespace Sales_mvc.Services
{
    public class DepartmentService
    {
        private readonly Sales_mvcContext context;

        public DepartmentService(Sales_mvcContext context)
        {
            this.context = context;
        }

        public async Task<List<Department>> FindAllAsync()
        {
            return await context.Department.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
