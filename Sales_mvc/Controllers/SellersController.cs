﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sales_mvc.Models;
using Sales_mvc.Models.ViewModels;
using Sales_mvc.Services;

namespace Sales_mvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService sellerService;
        private readonly DepartmentService departmentService;

        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            this.sellerService = sellerService;
            this.departmentService = departmentService;
        }

        public IActionResult Index()
        {
            var list = sellerService.FindAll();

            return View(list);
        }

        public IActionResult Create()
        {
            var departments = departmentService.FindAll();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var obj = sellerService.FindById(id.Value);
            if(obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            sellerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}