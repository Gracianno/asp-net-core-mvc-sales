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

        public async Task<List<Seller>> FindAllAsync()
        {
            return await context.Sellers.ToListAsync();
        }

        public async Task InsertAsync(Seller obj)
        {
            context.Add(obj);
            await context.SaveChangesAsync();
        }

        public async Task<Seller> FindByIdAsync(int id)
        {
            return await context.Sellers.Include(obj => obj.department).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await context.Sellers.FindAsync(id);
                context.Sellers.Remove(obj);
                await context.SaveChangesAsync();
            }
            catch(DbUpdateException e)
            {
                throw new IntegratyExpetion(e.Message);
            }

        }

        public async Task UpdateAsync(Seller obj)
        {
            bool hasAny = await context.Sellers.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                context.Update(obj);
                await context.SaveChangesAsync();
            }catch(DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

    }
}
