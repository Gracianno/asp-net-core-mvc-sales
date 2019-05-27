using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public List<Department> FindAll()
        {
            return context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
