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
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        public OrdersController(IOrderService orderService,IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _orderService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<OrderDto>>(orders));

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _orderService.GetByIdAsync(id);
            return Ok(_mapper.Map<OrderDto>(order));
        }

        [HttpGet("{id}/products/user")]
        public async Task<IActionResult> GetWithProductandUserById(int id)
        {
            var order = await _orderService.GetOrderWithProductAndUser(id);
            return Ok(_mapper.Map<OrderWithProductsAndUserDto>(order));
        }
        [HttpGet("products/user")]
        public async Task<IActionResult> GetAllProductAndUser()
        {
            var orders = await _orderService.GetAllWithProductAndUser();
            return Ok(_mapper.Map<IEnumerable<OrderWithProductsAndUserDto>>(orders));
        }
        [HttpPost("search/{date}")]
        public async Task<IActionResult> SearchByOrderDates(DateTime date)
        {
            var searchByOrderDate = await _orderService.Where(x => x.dateTime==date);
            return Ok(_mapper.Map<IEnumerable<OrderDto>>(searchByOrderDate));
        }
        [HttpPost]
        public async Task<IActionResult> Save(OrderDto orderDto)
        {
           var newOrder= await _orderService.AddAsync(_mapper.Map<Order>(orderDto));
            return Created(string.Empty, _mapper.Map<OrderDto>(newOrder));
        }
        [HttpPut]
        public IActionResult Update(OrderDto orderDto)
        {
            var order = _orderService.Update(_mapper.Map<Order>(orderDto));
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var order = _orderService.GetByIdAsync(id).Result;
            _orderService.Remove(order);
            return NoContent();
        }
    }
}
