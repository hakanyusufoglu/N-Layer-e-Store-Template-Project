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
    }
}
