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
    public class ProductsController : ControllerBase
    {
        private readonly IService<Product> _service;
        private readonly IMapper _mapper;
        public ProductsController(IService<Product> service,IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _service.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<ProductDto>>(products));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);
            return Ok(_mapper.Map<ProductDto>(product));
        }
        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var newProduct=await _service.AddAsync(_mapper.Map<Product>(productDto));
            return Ok(_mapper.Map<ProductDto>(newProduct));
        }
        [HttpPut]
        public IActionResult Update(ProductDto productDto)
        {
            _service.Update(_mapper.Map<Product>(productDto));
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var entity = _service.GetByIdAsync(id).Result;
            _service.Remove(entity);
            return NoContent();
        }
    }
}
