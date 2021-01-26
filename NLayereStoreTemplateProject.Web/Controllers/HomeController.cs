using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayereStoreTemplateProject.Web.ApiService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Index()
        {
            var products = await _productApiService.GetAllAsync();
            var categories = await _categoryApiService.GetAllAsync();
            ViewBag.Categories = categories;
            return View(products);
        }
    }
}
