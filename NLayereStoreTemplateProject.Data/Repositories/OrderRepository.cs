using Microsoft.EntityFrameworkCore;
using NLayereStoreTemplateProject.Core.Entities;
using NLayereStoreTemplateProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NLayereStoreTemplateProject.Data.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }
        public OrderRepository(AppDbContext context ):base(context)
        {

        }
        public async Task<Order> GetOrderWithProductAndUser(int orderId)
        {
            return await _appDbContext.Orders.Include(x => x.Product).Include(x => x.User).SingleOrDefaultAsync(x => x.OrderId == orderId);
        }
    }
}
