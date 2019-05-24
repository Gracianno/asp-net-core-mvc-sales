using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sales_mvc.Services;

namespace Sales_mvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService sellerService;

        public SellersController(SellerService sellerService)
        {
            this.sellerService = sellerService;
        }

        public IActionResult Index()
        {
            var list = sellerService.FindAll();

            return View(list);
        }
    }
}