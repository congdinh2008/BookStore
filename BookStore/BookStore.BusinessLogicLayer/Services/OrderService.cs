using BookStore.DataAccessLayer;
using BookStore.Models;

namespace BookStore.BusinessLogicLayer
{
    public class OrderService : BaseService<Order>, IOrderService
    {
        public OrderService(IUnitOfWork unitOfWork, IGenericRepository<Order> repository) : base(unitOfWork, repository)
        {
        }
    }
}
