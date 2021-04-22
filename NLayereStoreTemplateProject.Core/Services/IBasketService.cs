using NLayereStoreTemplateProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NLayereStoreTemplateProject.Core.Services
{
    public interface IBasketService:IService<Basket>
    {
        Task<IEnumerable<Basket>> GetAllWithProductAndUserBasket();
        Task<Basket> GetWithProductAndBasketByUserId(int userId);
    }
}
