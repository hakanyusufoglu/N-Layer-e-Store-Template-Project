using Microsoft.AspNetCore.Mvc;
using NLayereStoreTemplateProject.Web.ApiService;
using NLayereStoreTemplateProject.Web.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayereStoreTemplateProject.Web.Controllers
{
    public class BasketsController : Controller
    {
        private readonly BasketApiService _basketApiService;
        public BasketsController(BasketApiService basketApiService)
        {
            _basketApiService = basketApiService;
        }
        public async Task<IActionResult> Index()
        {
            var baskets = await _basketApiService.GetAllAsyncByUserId(1);
            var test = baskets.Where(x => x.IsDeleted == false).ToList();
            return View(test);
        }
        [HttpPost]
        public async Task<IActionResult> Save(BasketDto basketDto)
        {
            await _basketApiService.AddAsync(basketDto);
            return RedirectToAction("Index","Home");
        }

        
        [HttpPost]
        public async Task<IActionResult> Update(BasketDto basketDto, int productQuantity)
        {
            basketDto.Quantity = productQuantity;
            await _basketApiService.Update(basketDto);
            return RedirectToAction("Index", "Baskets");
        }
        public async Task<IActionResult> Remove(int id)
        {
            bool test = await _basketApiService.Remove(id);
            return RedirectToAction("Index");
        }
       
    }
}
