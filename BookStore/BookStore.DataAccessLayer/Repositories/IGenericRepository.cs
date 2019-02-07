using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookStore.DataAccessLayer
{
    public interface IGenericRepository<TEntity> where TEntity: class
    {
        TEntity Add(TEntity entity);
        void Update(TEntity entity);
        TEntity Delete(TEntity entity);
        IEnumerable<TEntity> DeleteBy(Expression<Func<TEntity, bool>> filter);

        int Count();
        Task<int> CountAsync();

        TEntity GetById(object id);
        Task<TEntity> GetByIdAsync(object id);

        IQueryable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync();

        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        TEntity Find(Expression<Func<TEntity, bool>> filter);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> filter);

        IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> filter);
        Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> filter);
        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> filter);
    }
}
