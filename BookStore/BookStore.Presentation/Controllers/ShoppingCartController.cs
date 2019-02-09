using BookStore.BusinessLogicLayer;
using BookStore.Common;
using BookStore.Models;
using BookStore.Presentation.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BookStore.Presentation.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IBookService _bookService;

        public ShoppingCartController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public ActionResult Index()
        {
            var cart = Session[ConstantCommon.Cart] as List<ShoppingCartItem> ?? new List<ShoppingCartItem>();

            if (cart.Count == 0 || Session[ConstantCommon.Cart] == null)
            {
                ViewBag.Message = "Don't have any item in your cart.";
                return View();
            }

            decimal total = 0m;
            foreach (var item in cart)
            {
                total += item.Total;
            }
            ViewBag.GrandTotal = total;

            return View(cart);
        }

        public ActionResult CartPartial()
        {
            ShoppingCartItem model = new ShoppingCartItem();

            int qty = 0;
            decimal price = 0m;
            if (Session[ConstantCommon.Cart] != null)
            {
                var list = (List<ShoppingCartItem>)Session[ConstantCommon.Cart];
                foreach (var item in list)
                {
                    qty += item.Quantity;
                    price += item.Quantity * item.Price;
                }
                model.Quantity = qty;
                model.Price = price;
            }
            else
            {
                model.Quantity = 0;
                model.Price = 0m;
            }

            return PartialView(model);
        }

        public async Task<ActionResult> AddToCartPartial(int id)
        {
            List<ShoppingCartItem> cart = Session[ConstantCommon.Cart] as List<ShoppingCartItem> ?? new List<ShoppingCartItem>();

            ShoppingCartItem model = new ShoppingCartItem();

            Book book = await _bookService.GetByIdAsync(id);

            var itemInCart = cart.FirstOrDefault(x => x.BookId == id);

            if (itemInCart == null)
            {
                cart.Add(new ShoppingCartItem()
                {
                    Book = book,
                    BookId = book.BookId,
                    Quantity = 1,
                    Price = book.Price,
                });
            }
            else
            {
                itemInCart.Quantity++;
            }

            int qty = 0;
            decimal price = 0m;
            foreach (var item in cart)
            {
                qty += item.Quantity;
                price += item.Quantity * item.Price;
            }
            model.Quantity = qty;
            model.Price = price;
            Session[ConstantCommon.Cart] = cart;

            return PartialView(model);
        }

        public JsonResult IncrementProduct(int bookId)
        {
            List<ShoppingCartItem> cart = Session[ConstantCommon.Cart] as List<ShoppingCartItem>;

            ShoppingCartItem item = cart.FirstOrDefault(x => x.BookId == bookId);

            item.Quantity++;

            var result = new { qty = item.Quantity, price = item.Price };

            return Json(result, JsonRequestBehavior.AllowGet);

        }

        public ActionResult DecrementProduct(int bookId)
        {
            List<ShoppingCartItem> cart = Session[ConstantCommon.Cart] as List<ShoppingCartItem>;

            ShoppingCartItem item = cart.FirstOrDefault(x => x.BookId == bookId);

            if (item.Quantity > 1)
            {
                item.Quantity--;
            }
            else
            {
                item.Quantity = 0;
                cart.Remove(item);
            }

            var result = new { qty = item.Quantity, price = item.Price };

            return Json(result, JsonRequestBehavior.AllowGet);

        }

        public void RemoveProduct(int bookId)
        {
            List<ShoppingCartItem> cart = Session[ConstantCommon.Cart] as List<ShoppingCartItem>;

            ShoppingCartItem item = cart.FirstOrDefault(x => x.BookId == bookId);

            cart.Remove(item);

        }
    }
}