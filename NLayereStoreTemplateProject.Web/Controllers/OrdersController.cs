using Microsoft.AspNetCore.Mvc;
using NLayereStoreTemplateProject.Web.ApiService;
using NLayereStoreTemplateProject.Web.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayereStoreTemplateProject.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly OrderApiService _orderApiService;
        private readonly BasketApiService _basketApiService;
        public OrdersController(OrderApiService orderApiService, BasketApiService basketApiService)
        {
            _orderApiService = orderApiService;
            _basketApiService = basketApiService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var orders =await _orderApiService.GetAllOrderWithProductUserAsync();
            return View(orders);
        }
        
        public async Task<IActionResult> Save()
        { //This operation can be in Bussiness service layer
            var orders = await _basketApiService.GetAllAsyncByUserId(1); //number 1 to change for jwt learning
            List<OrderDto> orderDtos = new List<OrderDto>();
            List<BasketDto> basketDtos = new List<BasketDto>();
            foreach (var item in orders)
            {
                orderDtos.Add(new OrderDto
                {
                    dateTime = DateTime.Now,
                    OrderCount = item.Quantity,
                    PaymentType = PaymentType.CreditCard, //can be update later
                    Status = OrderStatus.Preparing, //can be update later
                    IsDeleted = false,
                    ProductId = item.Product.ProductId,
                    UnitPrice = item.Product.Price,
                    TotalPrice = (item.Product.Price * item.Quantity),
                    UserId = item.User.UserId
                });
                basketDtos.Add(new BasketDto { 
                    BasketId = item.BasketId,
                    ProductId = item.Product.ProductId,
                    Quantity = item.Quantity,
                    UserId = item.User.UserId,
                    CreateDate=item.CreateDate,
                    IsDeleted=true
                });
            }
        
           var orderCompleted=  await _orderApiService.AddRangeAsync(orderDtos);
            if (orderCompleted != null)
            {
                await _basketApiService.UpdateRange(basketDtos);
            }
            return RedirectToAction("Index", "Orders");
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
