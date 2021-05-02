using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayereStoreTemplateProject.Api.DTOs;
using NLayereStoreTemplateProject.Core.Entities;
using NLayereStoreTemplateProject.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayereStoreTemplateProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly IMapper _mapper;
        public BasketsController(IBasketService basketSservice, IMapper mapper)
        {
            _basketService = basketSservice;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var baskets = await _basketService.GetAllWithProductAndUserBasket();
            return Ok(_mapper.Map<IEnumerable<BasketandProductsUserDto>>(baskets));
        }
        [HttpGet("{id}/products/user")]
        public async Task<IActionResult>GetAllBasketByUserId(int id)
        {
            var basketsByUserId = (await _basketService.GetAllWithProductAndUserBasket()).Where(x => x.UserId == id).ToList();
            return Ok(_mapper.Map<IEnumerable<BasketandProductsUserDto>>(basketsByUserId));
        }
        [HttpPost]
        public async Task<IActionResult> Save(BasketsDto basketDto)
        {
            var newBasket = await _basketService.AddAsync(_mapper.Map<Basket>(basketDto));
            return Created(string.Empty, _mapper.Map<BasketsDto>(newBasket));
        }
        //quantity property value change 
        [HttpPut]
        public IActionResult Update(BasketsDto basket)
        {
            _basketService.Update(_mapper.Map<Basket>(basket));
            return NoContent();
        }
        //example: productId 1 and userId 2 delete
        [HttpDelete("{productId}/userId/{userId}")]
        public IActionResult RemoveRange(int productId,int userId)
        {
            var entities = _basketService.Where(x => x.ProductId == productId).Result.Where(x=>x.UserId==userId);
            _basketService.RemoveRange(entities);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public  IActionResult Remove(int id)
        {
            var entity =  _basketService.Where(x => x.BasketId == id).Result.FirstOrDefault();
            _basketService.Remove(entity);
            return NoContent();
        }
    }
}
