using BookStore.Models;
using System.Collections.Generic;

namespace BookStore.BusinessLogicLayer
{
    public interface ICheckoutService
    {
        void CheckoutAsync(Order order, List<OrderDetail> orderDetails);
    }
}
