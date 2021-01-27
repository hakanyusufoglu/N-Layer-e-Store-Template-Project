using NLayereStoreTemplateProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NLayereStoreTemplateProject.Core.Repositories
{
    public interface IProductRepository:IRepository<Product>
    {
        //idye sahip olan ürünün kategoriside gelsin;
        Task<Product> GetWithCategoryByIdAsync(int productId);
    }
}
