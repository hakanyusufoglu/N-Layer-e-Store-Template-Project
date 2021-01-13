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
    public class CategoriesController : ControllerBase
    {
        private readonly IService<Category> _service;
        private readonly IMapper _mapper;

        public CategoriesController(IService<Category> service,IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _service.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<CategoryDto>>(categories)); // categoriesi categoryDto'ya çevirki kullanıcı sadece belirlenen alanları görsün.
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _service.GetByIdAsync(id);
            return Ok(_mapper.Map<CategoryDto>(category));
        }
        [HttpPost]
        public async Task<IActionResult> Save(CategoryDto categoryDto)
        {
            var newCategory = await _service.AddAsync(_mapper.Map<Category>(categoryDto));
            return Created(string.Empty, _mapper.Map<CategoryDto>(newCategory));
        }

        [HttpPut]
        public IActionResult Update(CategoryDto categoryDto)
        {
            _service.Update(_mapper.Map<Category>(categoryDto));
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var entity = _service.GetByIdAsync(id).Result;
            _service.Remove(entity);
            return NoContent();
        }
        //[HttpPost]
        //public async Task<IActionResult> SaveRange(List<CategoryDto> categoryDtos)
        //{
        //    var newCategories = await _service.AddRangeAsync(_mapper.Map<List<Category>>(categoryDtos));
        //    return Created(string.Empty, _mapper.Map<CategoryDto>(newCategories));
        //}
    }
}
