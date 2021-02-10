using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayereStoreTemplateProject.Core.Repositories
{
    //Tüm entity için ortak olan metotların tanımlanması;
    public interface IRepository<TEntity> where TEntity:class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id); //ID'ye göre generic tipte ki entity hangisiyse onu getir.
        Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate); //TEntity olan ve tipide bool olan bir metodu işaret et... 
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        Task<int> CountAsync();
        TEntity Update(TEntity entity);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
