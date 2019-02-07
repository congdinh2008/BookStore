using BookStore.DataAccessLayer;
using BookStore.Models;

namespace BookStore.BusinessLogicLayer
{
    public class OrderDetailService : BaseService<OrderDetail>, IOrderDetailService
    {
        public OrderDetailService(IUnitOfWork unitOfWork, IGenericRepository<OrderDetail> repository) : base(unitOfWork, repository)
        {
        }
    }
}
