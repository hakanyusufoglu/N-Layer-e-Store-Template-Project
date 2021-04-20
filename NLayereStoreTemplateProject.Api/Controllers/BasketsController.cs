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
        private readonly IService<Basket> _service;
        private readonly IMapper _mapper;
        public BasketsController(IService<Basket> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var baskets = await _service.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<BasketsDto>>(baskets));
        }
        [HttpPost]
        public async Task<IActionResult> Save(BasketsDto basketDto)
        {
            var newBasket = await _service.AddAsync(_mapper.Map<Basket>(basketDto));
            return Created(string.Empty, _mapper.Map<BasketsDto>(newBasket));
        }
    }
}
