using BookStore.DataAccessLayer;
using BookStore.Models;

namespace BookStore.BusinessLogicLayer
{
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork, IGenericRepository<Category> repository) : base(unitOfWork, repository)
        {
        }
    }
}
