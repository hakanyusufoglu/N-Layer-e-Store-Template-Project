using NLayereStoreTemplateProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NLayereStoreTemplateProject.Core.Services
{
   public interface IOrderService:IService<Order>
    {
        Task<Order> GetOrderWithProductAndUser(int orderId);
    }
}
