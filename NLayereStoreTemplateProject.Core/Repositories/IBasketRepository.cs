using NLayereStoreTemplateProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NLayereStoreTemplateProject.Core.Repositories
{
    public interface IBasketRepository:IRepository<Basket>
    {
        Task<IEnumerable<Basket>> GetAllWithProductAndUserBasket();
        Task<Basket> GetWithProductAndBasketByUserId(int userId);
    }
}
