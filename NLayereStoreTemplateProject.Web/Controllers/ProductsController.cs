﻿using Microsoft.AspNetCore.Mvc;
using NLayereStoreTemplateProject.Web.ApiService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayereStoreTemplateProject.Web.Controllers
{
    public class ProductsController : Controller
    {
       //private readonly ProductApiService _productApiService;
        /*public ProductsController(ProductApiService productApiService)
        {
            _productApiService = productApiService;
        }*/
      
        public IActionResult Index()
        {
           // var products = await _productApiService.GetAllAsync();
            return View();
        }
    }
}
