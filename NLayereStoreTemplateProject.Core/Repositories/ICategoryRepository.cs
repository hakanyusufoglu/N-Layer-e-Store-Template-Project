using NLayereStoreTemplateProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NLayereStoreTemplateProject.Core.Repositories
{
   public interface ICategoryRepository:IRepository<Category>
    {
        //verilen kategori Idye göre ürünler dönsün
        Task<Category> GetWithProductsByIdAsync(int categoryId);
    }
}
