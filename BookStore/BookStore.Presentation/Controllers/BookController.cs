using BookStore.BusinessLogicLayer;
using BookStore.Helpers;
using BookStore.Models;
using BookStore.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BookStore.Presentation.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookServices;
        private readonly ICategoryService _categoryServices;
        private readonly IReviewService _reviewServices;

        public BookController(
            IBookService bookServices,
            ICategoryService categoryServices,
            IReviewService reviewServices
            )
        {
            _bookServices = bookServices;
            _categoryServices = categoryServices;
            _reviewServices = reviewServices;
        }

        public async Task<ActionResult> ListByCategory(string category)
        {
            IEnumerable<Book> books;
            string currentCategory = string.Empty;

            if (category.IsBlank())
            {
                books = await _bookServices.GetAsync(orderBy: b => b.OrderBy(x => x.Title), page: 1, pageSize: 10);
                currentCategory = "All of Books";
            }
            else
            {
                books = await _bookServices.GetAsync(filter: b => b.Category.CategoryName == category, orderBy: b => b.OrderBy(x => x.Title), page: 1, pageSize: 10);

                currentCategory = category;
            }

            return View(new BooksListViewModel
            {
                Books = books,
                CurrentCategory = currentCategory
            });
        }

        public async Task<ActionResult> ListByPrice(decimal priceLevel)
        {
            IEnumerable<Book> books;
            decimal currentPrice = decimal.Zero;

            if (priceLevel < 0)
            {
                books = await _bookServices.GetAsync(orderBy: b => b.OrderBy(x => x.Title), page: 1, pageSize: 10);
                currentPrice = 0;
            }
            else
            {
                books = await _bookServices.GetAsync(filter: b => b.Price < priceLevel, orderBy: b => b.OrderBy(x => x.Title), page: 1, pageSize: 10);

                currentPrice = priceLevel;
            }

            return View(new BooksListByPriceViewModel
            {
                Books = books,
                CurrentPrice = currentPrice
            });
        }

        public async Task<ActionResult> ListByAuthor(string authorName)
        {
            IEnumerable<Book> books;
            string currentAuthor = string.Empty;

            if (string.IsNullOrEmpty(authorName))
            {
                books = await _bookServices.GetAsync(orderBy: b => b.OrderBy(x => x.Title), page: 1, pageSize: 10);
                currentAuthor = "Tất Cả Tác Giả";
            }
            else
            {
                books = await _bookServices.GetAsync(filter: b => b.Author.AuthorName == authorName, orderBy: b => b.OrderBy(x => x.Title), page: 1, pageSize: 10);

                currentAuthor = authorName;
            }

            return View(new BooksListByAuthorViewModel
            {
                Books = books,
                CurrentAuthor = currentAuthor
            });
        }

        public async Task<ActionResult> ListByPublisher(string publisherName)
        {
            IEnumerable<Book> books;
            string currentPublisher = string.Empty;

            if (string.IsNullOrEmpty(publisherName))
            {
                books = await _bookServices.GetAsync(orderBy: b => b.OrderBy(x => x.Title), page: 1, pageSize: 10);
                currentPublisher = "Tất Cả Các Nhà Xuất Bản";
            }
            else
            {
                books = await _bookServices.GetAsync(filter: b => b.Publisher.PublisherName == publisherName, orderBy: b => b.OrderBy(x => x.Title), page: 1, pageSize: 10);

                currentPublisher = publisherName;
            }

            return View(new BooksListByPublisherViewModel
            {
                Books = books,
                CurrentPublisher = currentPublisher
            });
        }

        public async Task<ActionResult> Details(int id)
        {
            var book = await _bookServices.GetByIdAsync(id);
            if (book == null)
                return HttpNotFound();

            var user = User.Identity.GetApplicationUser();


            var bookDetailViewModel = new BookDetailViewModel()
            {
                Book = book                
            };
            return View(bookDetailViewModel);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public async Task<ActionResult> Details(int id, string review)
        {
            var book = await _bookServices.GetByIdAsync(id);
            var user = User.Identity.GetApplicationUser();
            if (book == null)
                return HttpNotFound();

            string encodeReview = HtmlEncoder.Default.Encode(review);

            var bookReview = new Review()
            {
                UserId = user.Id,
                BookId = book.BookId,
                Comment = encodeReview,
                CreatedDate = DateTimeOffset.Now,
                IsActive = true
            };
            await _reviewServices.CreateAsync(bookReview);

            return RedirectToAction("Details");
        }
    }
}