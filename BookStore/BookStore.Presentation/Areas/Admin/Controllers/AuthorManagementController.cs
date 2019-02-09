using AutoMapper;
using BookStore.BusinessLogicLayer;
using BookStore.Helpers;
using BookStore.Models;
using BookStore.Presentation.Areas.Admin.ViewModels;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BookStore.Presentation.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrators, Manager")]
    public class AuthorManagementController: Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorManagementController(IAuthorService authorServices)
        {
            _authorService = authorServices;
        }

        public async Task<ActionResult> Index(string sortOrder, string currentFilter,
            string searchString, int? page)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = sortOrder.IsBlank() ? "name_desc" : "";
            ViewData["TotalSortParm"] = sortOrder == "Total" ? "total_desc" : "Total";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            Expression<Func<Author, bool>> filter = null;
            Func<IQueryable<Author>, IOrderedQueryable<Author>> orderBy = null;

            if (searchString.IsNotBlank())
            {
                filter = a => a.AuthorName.Contains(searchString);
            }
            switch (sortOrder)
            {
                case "name_desc":
                    orderBy = b => b.OrderByDescending(s => s.AuthorName);
                    break;
                case "Total":
                    orderBy = b => b.OrderBy(s => s.Books.Count());
                    break;
                case "total_desc":
                    orderBy = b => b.OrderByDescending(s => s.Books.Count());
                    break;
                default:
                    orderBy = b => b.OrderBy(s => s.AuthorName);
                    break;
            }

            var authors = await _authorService.GetAsync(filter: filter, orderBy: orderBy, page: page ?? 1, pageSize: 10);

            return View(authors);
        }

        public ActionResult AddAuthor()
        {
            var authorEditViewModel = new AuthorEditViewModel();
            return View(authorEditViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult AddAuthor(AuthorEditViewModel authorEditViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(authorEditViewModel);
            }

            var author = Mapper.Map<Author>(authorEditViewModel);

            _authorService.Create(author);

            return RedirectToAction("Index");
        }

        public ActionResult EditAuthor(int id)
        {
            var author = _authorService.GetById(id);

            var authorEditViewModel = Mapper.Map<AuthorEditViewModel>(author);

            return View(authorEditViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult EditAuthor(AuthorEditViewModel authorEditViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(authorEditViewModel);
            }
            
            var author = Mapper.Map<Author>(authorEditViewModel);

            _authorService.Update(author);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteAuthor(int id)
        {
            _authorService.Delete(id);

            return RedirectToAction("Index");
        }

        [AcceptVerbs("Get", "Post")]
        public ActionResult CheckIfAuthorNameAlreadyExists([Bind(Prefix = "Author.Name")]string name)
        {
            var author = _authorService.Find(x => x.AuthorName == name);
            return author == null ? Json(true) : Json("Author name exists");
        }
    }
}