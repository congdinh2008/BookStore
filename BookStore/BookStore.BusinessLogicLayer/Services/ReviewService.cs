using BookStore.DataAccessLayer;
using BookStore.Models;

namespace BookStore.BusinessLogicLayer
{
    public class ReviewService : BaseService<Review>, IReviewService
    {
        public ReviewService(IUnitOfWork unitOfWork, IGenericRepository<Review> repository) : base(unitOfWork, repository)
        {
        }
    }
}
