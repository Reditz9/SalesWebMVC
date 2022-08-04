using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Models.Entities;
using SalesWebMVC.Models.Services;
using SalesWebMVC.Models.ViewModels;
using System.Drawing.Text;

namespace SalesWebMVC.Controllers
{
    public class SellersController : Controller
    {

        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService,DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            var sellersList = _sellerService.FindAll();
            return View(sellersList);
        }
        //GET
        [HttpGet]
        public IActionResult Create()
        {
            var departments = _departmentService.FindAll();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if(id is null)
            {
                return NotFound();
            }
            var seller = _sellerService.FindById(id.Value);
            if(seller is null)
            {
                return NotFound();
            }
            return View(seller);
        }
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if(id is null)
            {
                return NotFound();
            }
            var seller = _sellerService.FindById(id.Value);
            if(seller is null)
            {
                return NotFound();
            }
            return View(seller);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Seller seller)
        {
            _sellerService.Remove(seller.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
