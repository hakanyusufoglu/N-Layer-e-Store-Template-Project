using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayereStoreTemplateProject.Web.ApiService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NLayereStoreTemplateProject.Web.DTOs;
using NLayereStoreTemplateProject.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace NLayereStoreTemplateProject.Web.Controllers
{
    public class HomeController : Controller //HomeController or ProductController
    {
        private readonly ProductApiService _productApiService;
        private readonly CategoryApiService _categoryApiService;
        private readonly IMapper _mapper;
        public HomeController(ProductApiService productApiService,CategoryApiService categoryApiService,IMapper mapper)
        {
            
            _productApiService = productApiService;
            _categoryApiService = categoryApiService;
            _mapper = mapper;
        }
  
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productApiService.GetAllAsync();
            
            var categories = await _categoryApiService.GetAllAsync();
            ViewBag.Categories =new SelectList(categories,"CategoryId","CategoryName");
            return View(products);
        }


        [HttpGet]
        public async Task<IActionResult> ProductDetails(int id)
        {
            var product = await _productApiService.GetProductWithCategoryAsync(id);
            return View(product);
        }

    
        public async Task<PartialViewResult> GetProductsPartial()
        {
            var products = await _productApiService.GetAllAsync();

            return PartialView(products);
        }
        [HttpPost]
        public async Task<IActionResult> ProductByCategory(int selectedCategoryId)
        {
            if (selectedCategoryId == 0)
            {
                return RedirectToAction("Index");
            }
            var category = await _categoryApiService.GetCategoryWithProductsAsync(selectedCategoryId);
            var categories = await _categoryApiService.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName", selectedCategoryId);
            return View(category);
        }
        //OLD VERSION VIEW
        [HttpGet]
        public async Task<IActionResult> OldIndex()
        {
            var products = await _productApiService.GetAllAsync();

            var categories = await _categoryApiService.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");
            return View(products);
        }

    }
}
