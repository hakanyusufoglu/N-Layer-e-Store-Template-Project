using NLayereStoreTemplateProject.Core.Entities;
using NLayereStoreTemplateProject.Core.Repositories;
using NLayereStoreTemplateProject.Core.Services;
using NLayereStoreTemplateProject.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NLayereStoreTemplateProject.Service.Services
{
    public class BasketService : Service<Basket>, IBasketService
    {
        
        public BasketService(IUnitOfWork unitOfWork, IRepository<Basket> repository):base(unitOfWork,repository)
        {

        }

        public async Task<IEnumerable<Basket>> GetAllWithProductAndUserBasket()
        {
            return await _unitOfWork.Basket.GetAllWithProductAndUserBasket();
        }

        public  async Task<Basket> GetWithProductAndBasketByUserId(int userId)
        {
            return await _unitOfWork.Basket.GetWithProductAndBasketByUserId(userId);
        }
    }
}
