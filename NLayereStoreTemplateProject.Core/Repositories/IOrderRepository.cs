using NLayereStoreTemplateProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NLayereStoreTemplateProject.Core.Repositories
{
  public  interface IOrderRepository:IRepository<Order>
    {
        Task<Order> GetOrderWithProductAndUser(int orderId);
        Task<IEnumerable<Order>> GetAllWithProductAndUser();
    }
}
