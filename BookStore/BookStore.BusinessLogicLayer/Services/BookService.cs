using BookStore.DataAccessLayer;
using BookStore.Models;

namespace BookStore.BusinessLogicLayer
{
    public class BookService : BaseService<Book>, IBookService
    {
        public BookService(IUnitOfWork unitOfWork, IGenericRepository<Book> repository) : base(unitOfWork, repository)
        {
        }
    }
}
