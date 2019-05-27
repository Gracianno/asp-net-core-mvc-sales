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

        public void Insert(Seller obj)
        {
            context.Add(obj);
            context.SaveChanges();
        }

        public Seller FindById(int id)
        {
            return context.Sellers.FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = context.Sellers.Find(id);
            context.Sellers.Remove(obj);
            context.SaveChanges();

        }
    }
}
