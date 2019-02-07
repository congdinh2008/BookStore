using BookStore.DataAccessLayer;
using BookStore.Models;

namespace BookStore.BusinessLogicLayer
{
    public class AuthorService : BaseService<Author>, IAuthorService
    {
        public AuthorService(IUnitOfWork unitOfWork, IGenericRepository<Author> repository) : base(unitOfWork, repository)
        {
        }
    }
}
