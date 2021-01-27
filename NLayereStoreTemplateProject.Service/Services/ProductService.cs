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
    public class ProductService : Service<Product>, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork,IRepository<Product> repository):base(unitOfWork,repository)
        {

        }
        public async Task<Product> GetWithCategoryByIdAsync(int productId)
        {
            return  await _unitOfWork.Product.GetWithCategoryByIdAsync(productId);
        }
    }
}
