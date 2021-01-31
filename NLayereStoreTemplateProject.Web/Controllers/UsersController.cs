using Microsoft.AspNetCore.Mvc;
using NLayereStoreTemplateProject.Web.ApiService;
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
    }
}
