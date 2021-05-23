using Microsoft.AspNetCore.Identity;
using NLayereStoreTemplateProject.Core.Entities;
using NLayereStoreTemplateProject.Core.Services;
using NLayereStoreTemplateProject.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayereStoreTemplateProject.Service.Services
{

    public class UserService : IUserService
    {
        private readonly UserManager<UserApp> _userManager;
        public UserService(UserManager<UserApp> userManager)
        {
            _userManager = userManager;
        }
        public async Task<UserApp> CreateUserAsync(UserApp userApp)
        {
            var result = await _userManager.CreateAsync(userApp);
            if (!result.Succeeded)
            {
                throw new Exception(); //after change with response class create
            }
            return userApp;
        }

        public Task<UserApp> GetUserByUsernameAsync(string userName)
        {
            var user = _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                throw new ArgumentNullException();
            }
            return user;
        }
    }
}
