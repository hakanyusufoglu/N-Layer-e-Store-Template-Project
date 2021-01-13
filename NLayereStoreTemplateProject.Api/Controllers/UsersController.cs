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
    public class UsersController : ControllerBase
    {
        private readonly IService<User> _service;
        private readonly IMapper _mapper;
        public UsersController(IService<User> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _service.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<UserDto>>(users));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _service.GetByIdAsync(id);
            return Ok(_mapper.Map<UserDto>(user));
        }
        [HttpPost]
        public async Task<IActionResult> Save(UserDto userDto)
        {
            var newUser = await _service.AddAsync(_mapper.Map<User>(userDto));
            return Created(string.Empty, _mapper.Map<UserDto>(newUser));
        }
        [HttpPut]
        public IActionResult Update(UserDto userDto)
        {
            _service.Update(_mapper.Map<User>(userDto));
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var user = _service.GetByIdAsync(id).Result;
            _service.Remove(user);
            return NoContent();
        }
    }
}