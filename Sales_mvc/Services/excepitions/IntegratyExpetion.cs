using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales_mvc.Services.excepitions
{
    public class IntegratyExpetion : ApplicationException
    {
        public IntegratyExpetion(string message) : base(message)
        {

        }
    }
}
