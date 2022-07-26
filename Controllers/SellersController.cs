﻿using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Models.Services;
using System.Drawing.Text;

namespace SalesWebMVC.Controllers
{
    public class SellersController : Controller
    {

        private readonly SellerService _sellerService;

        public SellersController(SellerService sellerService)
        {
            _sellerService = sellerService;
        }

        public  IActionResult Index()
        {
            var sellersList =  _sellerService.FindAll();
            return View(sellersList);
        }
    }
}