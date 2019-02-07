using BookStore.Common;
using BookStore.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookStore.BusinessLogicLayer
{
    public class BaseService<TEntity>: IBaseService<TEntity> where TEntity: class
    {
        #region Fields

        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IGenericRepository<TEntity> Repository;

        #endregion

        public BaseService(IUnitOfWork unitOfWork, IGenericRepository<TEntity> repository)
        {
            UnitOfWork = unitOfWork;
            Repository = repository;
        }

        public virtual int Count()
        {
            return Repository.Count();
        }

        public virtual async Task<int> CountAsync()
        {
            return await Repository.CountAsync();
        }

        public virtual int Create(TEntity entity)
        {
            Repository.Add(entity);
            return UnitOfWork.Commit();
        }

        public virtual async Task<int> CreateAsync(TEntity entity)
        {
            Repository.Add(entity);
            return await UnitOfWork.CommitAsync();
        }

        public virtual bool Delete(object id)
        {
            var entity = Repository.GetById(id);

            if (entity == null)
            {
                throw new Exception("Not found entity object with id: " + id);
            }
            Repository.Delete(entity);

            return UnitOfWork.Commit() > 0;
        }

        public virtual async Task<bool> DeleteAsync(object id)
        {
            var entity = await Repository.GetByIdAsync(id);

            if (entity == null)
            {
                throw new Exception("Not found entity object with id: " + id);
            }
            Repository.Delete(entity);

            return await UnitOfWork.CommitAsync() > 0;
        }

        public virtual TEntity Find(Expression<Func<TEntity, bool>> filter)
        {
            return Repository.Find(filter);
        }

        public virtual IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> filter)
        {
            return Repository.FindAll(filter);
        }

        public virtual async Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await Repository.FindAllAsync(filter);
        }

        public virtual async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await Repository.FindAsync(filter);
        }

        public virtual TEntity FindInclude(
            Expression<Func<TEntity, bool>> filter,
            string includeProperties = "")
        {
            var query = Repository.FindBy(filter);

            foreach (var includeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return query.FirstOrDefault();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Repository.GetAll();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Repository.GetAllAsync();
        }

        public async Task<PaginatedList<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "", int page = 1, int pageSize = 10)
        {
            var query = Repository.Get(filter: filter, includeProperties: includeProperties);
            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return await PaginatedList<TEntity>.CreateAsync(query.AsNoTracking(), page, pageSize);
        }

        public virtual TEntity GetById(object id)
        {
            return Repository.GetById(id);
        }

        public virtual async Task<TEntity> GetByIdAsync(object id)
        {
            return await Repository.GetByIdAsync(id);
        }

        public virtual bool Update(TEntity entity)
        {
            Repository.Update(entity);
            return UnitOfWork.Commit() > 0;
        }

        public virtual async Task<bool> UpdateAsync(TEntity entity)
        {
            Repository.Update(entity);
            return await UnitOfWork.CommitAsync() > 0;
        }
    }
}
