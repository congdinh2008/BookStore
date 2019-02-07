using BookStore.DataAccessLayer;
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Transactions;

namespace BookStore.BusinessLogicLayer
{
    public class CheckoutService : ICheckoutService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Order> _orderRepository;
        private readonly IGenericRepository<OrderDetail> _orderDetailRepository;
        private readonly IGenericRepository<Book> _bookRepository;

        public CheckoutService(
            IUnitOfWork unitOfWork,
            IGenericRepository<Order> orderRepository,
            IGenericRepository<OrderDetail> orderDetailRepository,
            IGenericRepository<Book> bookRepository)
        {
            _unitOfWork = unitOfWork;
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _bookRepository = bookRepository;
        }
        public async void CheckoutAsync(Order order, List<OrderDetail> orderDetails)
        {
            using (var transaction = new TransactionScope())
            {
                order.CreatedDate = DateTimeOffset.Now;
                order.ShippedDate = DateTimeOffset.Now.AddDays(4);

                _orderRepository.Add(order);

                foreach (var orderDetail in orderDetails)
                {
                    var book = _bookRepository.GetById(orderDetail.BookId);
                    book.Quantity -= orderDetail.Quantity;
                    _bookRepository.Update(book);
                    orderDetail.Order = order;
                    _orderDetailRepository.Add(orderDetail);
                }
                await _unitOfWork.CommitAsync();
                transaction.Complete();
            }
        }
    }
}
