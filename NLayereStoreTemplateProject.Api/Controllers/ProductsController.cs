﻿using AutoMapper;
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
        private readonly   IProductService _productservice;
        private readonly IMapper _mapper;
        public ProductsController(IProductService productService,IMapper mapper)
        {
            _productservice = productService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productservice.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<ProductDto>>(products));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productservice.GetByIdAsync(id);
            return Ok(_mapper.Map<ProductDto>(product));
        }
        [HttpGet("{id}/category")]
        public async Task<IActionResult> GetWithCategoryById(int id)
        {
            var product = await _productservice.GetWithCategoryByIdAsync(id);
            return Ok(_mapper.Map<ProductWithCategoryDto>(product));
        }
        [HttpGet("category")]
        public async Task<IActionResult> GetAllWithCategory()
        {
            var product = await _productservice.GetAllWithCategoryAsync();
            return Ok(_mapper.Map<IEnumerable<ProductWithCategoryAndBrandDto>>(product));
        }
        [HttpGet("count")]
        public async Task<IActionResult> GetCount()
        {
            int count = await _productservice.CountAsync();
            return Ok(count);
        }
        [HttpPost("search/{productName}")]
        public async Task<IActionResult> SearchByProductNames(string productName)
        {
            var SearchByProductName = await _productservice.Where(x => x.Name.ToLower().Contains(productName.ToLower()));
            return Ok(_mapper.Map<IEnumerable<ProductDto>>(SearchByProductName));
        }
        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var newProduct=await _productservice.AddAsync(_mapper.Map<Product>(productDto));
            return Ok(_mapper.Map<ProductDto>(newProduct));
        }
        [HttpPut]
        public IActionResult Update(ProductDto productDto)
        {
            _productservice.Update(_mapper.Map<Product>(productDto));
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var entity = _productservice.GetByIdAsync(id).Result;
            _productservice.Remove(entity);
            return NoContent();
        }
    }
}
