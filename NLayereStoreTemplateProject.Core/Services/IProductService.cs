using NLayereStoreTemplateProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NLayereStoreTemplateProject.Core.Services
{
   public interface IProductService:IService<Product>
    {
        Task<Product> GetWithCategoryByIdAsync(int productId);
    }
}
