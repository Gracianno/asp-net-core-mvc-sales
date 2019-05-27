using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sales_mvc.Models;

namespace Sales_mvc.Services
{
    public class SalesRecordService
    {
        private readonly Sales_mvcContext context;
        public SalesRecordService(Sales_mvcContext context)
        {
            this.context = context;
        }

        public async Task<List<SalesRecord>> FindBydate(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in context.SalesRecords select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }

            return await result
                .Include(x => x.seller)
                .Include(x => x.seller.department)
                .OrderByDescending(x => x.Date)
                .ToListAsync();
        }
    }
}
