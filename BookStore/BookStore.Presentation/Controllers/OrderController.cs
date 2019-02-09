using AutoMapper;
using BookStore.BusinessLogicLayer;
using BookStore.Common;
using BookStore.Models;
using BookStore.Presentation.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BookStore.Presentation.Controllers
{
    public class OrderController : Controller
    {
        private const string CartSession = "CartSession";
        private readonly IOrderService _orderService;
        private readonly ICheckoutService _checkoutService;

        public OrderController(IOrderService orderService, ICheckoutService checkoutService)
        {
            _orderService = orderService;
            _checkoutService = checkoutService;
        }

        [Authorize]
        public ActionResult Checkout()
        {
            if (Request.IsAuthenticated)
            {
                var user = User.Identity.GetApplicationUser();
                var orderViewModel = new OrderViewModel()
                {
                    ShipName = user.Name,
                    ShipAddress = user.Address,
                    ShipCity = user.City,
                    PhoneNumber = user.PhoneNumber
                };
                return View(orderViewModel);
            }
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Checkout(OrderViewModel orderViewModel)
        {
            var cart = Session[ConstantCommon.Cart];
            var cartItems = (List<ShoppingCartItem>)cart;

            if (cartItems.Count == 0)
            {
                ModelState.AddModelError("", "Giỏ hàng của bạn hiện trống không ah ^_^, chọn mua vài cuốn nhé!");
            }

            if (ModelState.IsValid)
            {
                List<OrderDetail> orderDetails = new List<OrderDetail>();

                foreach (var item in cartItems)
                {
                    var orderDetail = new OrderDetail()
                    {
                        Book = item.Book,
                        BookId = item.BookId,
                        Quantity = item.Quantity,
                        UnitPrice = item.Book.Price,
                    };
                    orderDetails.Add(orderDetail);
                }
                var order = new Order()
                {
                    ShipName = orderViewModel.ShipName,
                    ShipAddress = orderViewModel.ShipAddress,
                    ShipCity = orderViewModel.ShipCity,
                    PhoneNumber = orderViewModel.PhoneNumber
                };

                _checkoutService.Checkout(order, orderDetails);

                cartItems.Clear();

                return RedirectToAction("CheckoutComplete");
            }

            return View(orderViewModel);
        }

        public ActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = HttpContext.User.Identity.GetApplicationUser().Name + ", cảm ơn bạn đã đặt hàng, đơn hàng của bạn sẽ sớm được chuyển tới ^_^";

            return View();
        }
    }
}
