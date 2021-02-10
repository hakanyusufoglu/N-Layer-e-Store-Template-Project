using Microsoft.AspNetCore.Mvc;
using NLayereStoreTemplateProject.Web.ApiService;
using NLayereStoreTemplateProject.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayereStoreTemplateProject.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly ProductApiService _productApiService;
        private readonly OrderApiService _orderApiService;
        private readonly UserApiService _userApiService;
        public AdminController(ProductApiService productApiService,OrderApiService orderApiService, UserApiService userApiService)
        {
            _orderApiService = orderApiService;
            _productApiService = productApiService;
            _userApiService = userApiService;
        }
        public async Task<IActionResult> Index()
        {
            var dashBoardViewModel = new DashBoardViewModel
            {
                ProductCount = await _productApiService.GetCount(),
                OrderCount = await _orderApiService.GetCount(),
                UserCount = await _userApiService.GetCount()
            };
            return View(dashBoardViewModel);
        }
    }
}
