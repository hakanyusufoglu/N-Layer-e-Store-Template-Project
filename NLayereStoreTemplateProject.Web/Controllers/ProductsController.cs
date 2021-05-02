using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NLayereStoreTemplateProject.Web.ApiService;
using NLayereStoreTemplateProject.Web.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayereStoreTemplateProject.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductApiService _productApiService;
        private readonly CategoryApiService _categoryApiService;
        private readonly BrandApiService _brandApiService;
        public ProductsController(ProductApiService productApiService,CategoryApiService categoryApiService,BrandApiService brandApiService)
        {
            _productApiService = productApiService;
            _categoryApiService = categoryApiService;
            _brandApiService = brandApiService;
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
            if(searchName!=null)
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

        public async Task<IActionResult> Update(int id)
        {
            var product = await _productApiService.GetByIdAsync(id);
            var categories = await _categoryApiService.GetAllAsync();

            var brands = await _brandApiService.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName",product.CategoryId);
            ViewBag.Brands = new SelectList(brands, "BrandId", "Name",product.BrandId);
            return PartialView("~/Views/Shared/PartialViews/ProductsPartialViews/_ProductUpdatePartialViews.cshtml", product);
        }
        [HttpPost]
        public async Task<IActionResult> Update(ProductDto productDto, int selectedCategoryId, int selectedBrandId)
        {
            productDto.CategoryId = selectedCategoryId;
            productDto.BrandId= selectedBrandId;
            await _productApiService.Update(productDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(int id)
        {
            await _productApiService.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
