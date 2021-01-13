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
    public class OrderService : Service<Order>, IOrderService
    {
        public OrderService(IUnitOfWork unitOfWork,IRepository<Order> repository):base(unitOfWork,repository)
        {

        }
        public async Task<Order> GetOrderWithProductAndUser(int orderId)
        {
            return await _unitOfWork.Order.GetOrderWithProductAndUser(orderId);
        }
    }
}
