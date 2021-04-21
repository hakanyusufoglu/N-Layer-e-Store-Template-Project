using Microsoft.EntityFrameworkCore;
using NLayereStoreTemplateProject.Core.Entities;
using NLayereStoreTemplateProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NLayereStoreTemplateProject.Data.Repositories
{
    public class BasketRepository : Repository<Basket>, IBasketRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }
       

        public BasketRepository(AppDbContext context) : base(context)
        {

        }
        public async Task<IEnumerable<Basket>> GetAllWithProductAndUserBasket()
        {
            return await _appDbContext.Baskets.Include(x => x.User).Include(x => x.Product).ToListAsync();
        }

        public async Task<Basket> GetWithProductAndBasketByUserId(int userId)
        {
            return await _appDbContext.Baskets.Include(x => x.Product).Include(x => x.User).FirstOrDefaultAsync(x=>x.UserId==userId);
        }
    }
}
