using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales_mvc.Services.excepitions
{
    public class DbConcurrencyException : ApplicationException
    {
        public DbConcurrencyException(string message) : base(message)
        {

        }
    }
}
