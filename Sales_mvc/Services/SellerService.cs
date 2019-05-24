using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sales_mvc.Models;

namespace Sales_mvc.Services
{
    public class SellerService
    {
        private readonly Sales_mvcContext context;

        public SellerService(Sales_mvcContext context)
        {
            this.context = context;
        }

        public List<Seller> FindAll()
        {
            return context.Sellers.ToList();
        }
    }
}
