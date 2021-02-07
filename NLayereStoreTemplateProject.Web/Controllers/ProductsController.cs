using Microsoft.AspNetCore.Mvc;
using NLayereStoreTemplateProject.Web.ApiService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayereStoreTemplateProject.Web.Controllers
{
    public class ProductsController : Controller
    {
       private readonly ProductApiService _productApiService;
        public ProductsController(ProductApiService productApiService)
        {
            _productApiService = productApiService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productApiService.GetAllProductwithCategoryAsync();
            return View(products);
        }

        // ARAMA İŞLEMİNDE PROBLEM OLUYOR; bu yüzden _productApiService içinde ki search metodu kullanılmadı; (iyileştirilecektir) 

        [HttpPost]
        public async Task<IActionResult> Search(string searchName)
        {
            var searchProduct = await _productApiService.GetAllProductwithCategoryAsync();
           searchProduct = searchProduct.Where(x => x.Name.ToLower().Contains(searchName.ToLower()));
            if (searchProduct != null)
            {
                return View("Index", searchProduct);
            }
            else
            {
                return RedirectToAction("Index");
            }

        }
    }
}
