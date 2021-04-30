using Microsoft.AspNetCore.Mvc;
using NLayereStoreTemplateProject.Web.ApiService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayereStoreTemplateProject.Web.ViewComponents
{ //Henüz kullanılmıyor dikkate almayınız (Not using).
    public class ProductsViewComponent:ViewComponent
    {
        private readonly ProductApiService _productApiService;
        public ProductsViewComponent(ProductApiService productApiService)
        {
            _productApiService = productApiService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var products = await _productApiService.GetAllAsync();
            return View(products);
        }
    }
}
