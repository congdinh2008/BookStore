using BookStore.DataAccessLayer;
using BookStore.Models;

namespace BookStore.BusinessLogicLayer
{
    public class PublisherService : BaseService<Publisher>, IPublisherService
    {
        public PublisherService(IUnitOfWork unitOfWork, IGenericRepository<Publisher> repository) : base(unitOfWork, repository)
        {
        }
    }
}
