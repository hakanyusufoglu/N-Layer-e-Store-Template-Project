using Microsoft.AspNetCore.Mvc;
using NLayereStoreTemplateProject.Web.ApiService;
using NLayereStoreTemplateProject.Web.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayereStoreTemplateProject.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserApiService _userApiService;
        public UsersController(UserApiService userApiService)
        {
            _userApiService = userApiService;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userApiService.GetAllAsync();
            return View(users);
        }
        public IActionResult Save()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Save(UserDto userDto)
        {
            await _userApiService.AddAsync(userDto);
            return RedirectToAction("Index");
        }
     
        public async Task<IActionResult> Update(int id)
        {
            var user =await _userApiService.GetByIdAsync(id);
            return PartialView("~/Views/Shared/PartialViews/UsersPartialViews/_UserUpdatePartialViews.cshtml", user);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UserDto userDto)
        {
            await _userApiService.Update(userDto);
            return RedirectToAction("Index");
        }
    
 
        public async Task<IActionResult> Remove(int id)
        {
            await _userApiService.Remove(id);
            return RedirectToAction("Index");
        }

    }
}
