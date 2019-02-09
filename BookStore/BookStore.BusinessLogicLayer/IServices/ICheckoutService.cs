using BookStore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.BusinessLogicLayer
{
    public interface ICheckoutService
    {
        void Checkout(Order order, List<OrderDetail> orderDetails);
    }
}
