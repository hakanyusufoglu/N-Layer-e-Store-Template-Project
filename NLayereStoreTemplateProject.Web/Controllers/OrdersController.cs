using Microsoft.AspNetCore.Mvc;
using NLayereStoreTemplateProject.Web.ApiService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayereStoreTemplateProject.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly OrderApiService _orderApiService;
        public OrdersController(OrderApiService orderApiService)
        {
            _orderApiService = orderApiService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var orders =await _orderApiService.GetAllOrderWithProductUserAsync();
            return View(orders);
        }
    }
}
