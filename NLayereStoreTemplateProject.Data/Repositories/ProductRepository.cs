using NLayereStoreTemplateProject.Core.Entities;
using NLayereStoreTemplateProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace NLayereStoreTemplateProject.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }
        public ProductRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
        public async Task<Product> GetWithCategoryByIdAsync(int productId)
        {
            return await _appDbContext.Products.Include(x => x.Category).FirstOrDefaultAsync(x => x.ProductId == productId);
        }

        public async Task<IEnumerable<Product>> GetAllWithCategoryAsync()
        {
            return await _appDbContext.Products.Include(x => x.Category).Include(x=>x.Brand).ToListAsync();
        }
    }
}
