using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sales_mvc.Models;
using Sales_mvc.Services.excepitions;

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
            return context.Sellers.Include(obj => obj.department).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = context.Sellers.Find(id);
            context.Sellers.Remove(obj);
            context.SaveChanges();

        }

        public void Update(Seller obj)
        {
            if(!context.Sellers.Any(x=> x.Id == obj.Id))
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                context.Update(obj);
                context.SaveChanges();
            }catch(DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

    }
}
