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
        [HttpPost]
        public async Task<IActionResult> Search(DateTime searchDate)
        {
            var searchOrder = await _orderApiService.GetAllOrderWithProductUserAsync();
            searchOrder = searchOrder.Where(x => x.dateTime==searchDate);
            if (searchOrder != null)
            {
                return View("Index", searchOrder);
            }
            else
            {
                return RedirectToAction("Index");
            }

        }
    }
}
