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
    public class BrandsController : ControllerBase
    {
        private readonly IService<Brand> _service;
        private readonly IMapper _mapper;
        public BrandsController(IService<Brand> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var brands = await _service.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<BrandDto>>(brands));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var brand = await _service.GetByIdAsync(id);
            return Ok(_mapper.Map<BrandDto>(brand));
        }
        [HttpPost]
        public async Task<IActionResult> Save(BrandDto brandDto)
        {
            var newBrand = await _service.AddAsync(_mapper.Map<Brand>(brandDto));
            return Ok(_mapper.Map<ProductDto>(newBrand));
        }
        [HttpPut]
        public IActionResult Update(BrandDto brandDto)
        {
            _service.Update(_mapper.Map<Brand>(brandDto));
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
