using AutoMapper;
using BookStore.BusinessLogicLayer;
using BookStore.Helpers;
using BookStore.Models;
using BookStore.Presentation.Areas.Admin.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Presentation.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrators, Manager")]
    public class BookManagementController : Controller
    {
        private const string _ImagesPath = "~/Assets/images";
        private readonly IBookService _bookServices;
        private readonly ICategoryService _categoryServices;
        private readonly IAuthorService _authorServices;
        private readonly IPublisherService _publisherServices;

        public BookManagementController(
            IBookService bookServices,
            ICategoryService categoryServices,
            IAuthorService authorServices,
            IPublisherService publisherServices
            )
        {
            _bookServices = bookServices;
            _categoryServices = categoryServices;
            _authorServices = authorServices;
            _publisherServices = publisherServices;
        }

        public async Task<ActionResult> Index(string sortOrder, string currentFilter,
            string searchString, int? page)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["TitleSortParm"] = sortOrder.IsBlank() ? "title_desc" : "";
            ViewData["PriceSortParm"] = sortOrder == "Price" ? "price_desc" : "Price";
            ViewData["QuantitySortParm"] = sortOrder == "Quantity" ? "quantity_desc" : "Quantity";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            Expression<Func<Book, bool>> filter = null;
            Func<IQueryable<Book>, IOrderedQueryable<Book>> orderBy = null;

            if (searchString.IsNotBlank())
            {
                filter = b => b.Title.Contains(searchString);
            }
            switch (sortOrder)
            {
                case "title_desc":
                    orderBy = b => b.OrderByDescending(s => s.Title);
                    break;
                case "Price":
                    orderBy = b => b.OrderBy(s => s.Price);
                    break;
                case "price_desc":
                    orderBy = b => b.OrderByDescending(s => s.Price);
                    break;
                case "Quantity":
                    orderBy = b => b.OrderBy(s => s.Quantity);
                    break;
                case "quantity_desc":
                    orderBy = b => b.OrderByDescending(s => s.Quantity);
                    break;
                default:
                    orderBy = b => b.OrderBy(s => s.Title);
                    break;
            }

            var books = await _bookServices.GetAsync(filter: filter, orderBy: orderBy, page: page ?? 1, pageSize: 10);

            return View(books);
        }

        public async Task<ActionResult> AddBook()
        {
            List<Category> categories = await _categoryServices.GetAsync(orderBy: x => x.OrderBy(b => b.CategoryName), page: 1, pageSize: 10);
            ViewBag.Categories = new SelectList(categories.OrderBy(x => x.CategoryId), "CategoryId", "CategoryName");

            List<Author> authors = await _authorServices.GetAsync(orderBy: x => x.OrderBy(b => b.AuthorName), page: 1, pageSize: 10);
            ViewBag.Authors = new SelectList(authors.OrderBy(x => x.AuthorId), "AuthorId", "AuthorName");

            List<Publisher> publishers = await _publisherServices.GetAsync(orderBy: x => x.OrderBy(b => b.PublisherName), page: 1, pageSize: 10);
            ViewBag.Publishers = new SelectList(publishers.OrderBy(x => x.PublisherId), "PublisherId", "PublisherName");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public async Task<ActionResult> AddBook(BookEditViewModel bookEditViewModel, HttpPostedFileBase ImgUrl)
        {
            if (ModelState.IsValid)
            {
                string fileName = "";
                if (ImgUrl != null && ImgUrl.ContentLength > 0)
                {
                    try
                    {
                        fileName = Path.GetFileName(ImgUrl.FileName);
                        string path = Path.Combine(Server.MapPath(_ImagesPath), Path.GetFileName(ImgUrl.FileName));
                        ImgUrl.SaveAs(path);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                var book = Mapper.Map<Book>(bookEditViewModel);
                book.ImageUrl = fileName;
                await _bookServices.CreateAsync(book);

                return RedirectToAction("Index");
            }

            List<Category> categories = await _categoryServices.GetAsync(orderBy: x => x.OrderBy(b => b.CategoryName), page: 1, pageSize: 10);
            ViewBag.Categories = new SelectList(categories.OrderBy(x => x.CategoryId), "CategoryId", "CategoryName");

            List<Author> authors = await _authorServices.GetAsync(orderBy: x => x.OrderBy(b => b.AuthorName), page: 1, pageSize: 10);
            ViewBag.Authors = new SelectList(authors.OrderBy(x => x.AuthorId), "AuthorId", "AuthorName");

            List<Publisher> publishers = await _publisherServices.GetAsync(orderBy: x => x.OrderBy(b => b.PublisherName), page: 1, pageSize: 10);
            ViewBag.Publishers = new SelectList(publishers.OrderBy(x => x.PublisherId), "PublisherId", "PublisherName");

            return View(bookEditViewModel);
        }

        public async Task<ActionResult> EditBook(int id)
        {
            var book = await _bookServices.GetByIdAsync(id);
            if (book == null)
            {
                return HttpNotFound();
            }

            var bookEditViewModel = Mapper.Map<BookEditViewModel>(book);

            ViewBag.Categories = new SelectList(await _categoryServices.GetAsync(orderBy: x => x.OrderBy(b => b.CategoryName), page: 1, pageSize: 10), "CategoryId", "CategoryName", bookEditViewModel.CategoryId);
            ViewBag.Authors = new SelectList(await _authorServices.GetAsync(orderBy: x => x.OrderBy(b => b.AuthorName), page: 1, pageSize: 10), "AuthorId", "AuthorName", bookEditViewModel.AuthorId);
            ViewBag.Publishers = new SelectList(await _publisherServices.GetAsync(orderBy: x => x.OrderBy(b => b.PublisherName), page: 1, pageSize: 10), "PublisherId", "PublisherName", bookEditViewModel.PublisherId);

            return View(bookEditViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public async Task<ActionResult> EditBook(BookEditViewModel bookEditViewModel, HttpPostedFileBase ImgUrl)
        {
            if (ModelState.IsValid)
            {

                if (ImgUrl != null && ImgUrl.ContentLength > 0)
                {
                    string filePath = Path.Combine(Server.MapPath(_ImagesPath), Path.GetFileName(ImgUrl.FileName));
                    ImgUrl.SaveAs(filePath);
                    bookEditViewModel.ImageUrl = ImgUrl.FileName;
                }
                var book = Mapper.Map<Book>(bookEditViewModel);
                book.ImageUrl = bookEditViewModel.ImageUrl;
                await _bookServices.UpdateAsync(book);

                return RedirectToAction("Index");
            }

            ViewBag.Categories = new SelectList(await _categoryServices.GetAsync(orderBy: x => x.OrderBy(b => b.CategoryName), page: 1, pageSize: 10), "CategoryId", "CategoryName", bookEditViewModel.CategoryId);
            ViewBag.Authors = new SelectList(await _authorServices.GetAsync(orderBy: x => x.OrderBy(b => b.AuthorName), page: 1, pageSize: 10), "AuthorId", "AuthorName", bookEditViewModel.AuthorId);
            ViewBag.Publishers = new SelectList(await _publisherServices.GetAsync(orderBy: x => x.OrderBy(b => b.PublisherName), page: 1, pageSize: 10), "PublisherId", "PublisherName", bookEditViewModel.PublisherId);
            return View(bookEditViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteBook(int id)
        {
            await _bookServices.DeleteAsync(id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<JsonResult> AddCategory(Category category)
        {
            var task = Task.Run(() => _categoryServices.CreateAsync(category));
            var quoteId = await task;
            return Json(quoteId, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<JsonResult> AddPublisher(Publisher publisher)
        {
            var task = Task.Run(() => _publisherServices.CreateAsync(publisher));
            var quoteId = await task;
            return Json(quoteId, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<JsonResult> AddAuthor(Author author)
        {
            var task = Task.Run(() => _authorServices.CreateAsync(author));
            var quoteId = await task;
            return Json(quoteId, JsonRequestBehavior.AllowGet);
        }


        [AcceptVerbs("Get", "Post")]
        public ActionResult CheckIfBookTitleAlreadyExists([Bind(Prefix = "Book.Title")]string title)
        {
            var book = _bookServices.Find(b => b.Title == title);
            return book == null ? Json(true) : Json("Tựa sách này đã có sẵn");
        }
    }
}