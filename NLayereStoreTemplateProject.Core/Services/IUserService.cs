using NLayereStoreTemplateProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayereStoreTemplateProject.Core.Services
{
    public interface IUserService
    {
        Task<UserApp> CreateUserAsync(UserApp userApp);
        Task<UserApp> GetUserByUsernameAsync(string userName);

    }
}
