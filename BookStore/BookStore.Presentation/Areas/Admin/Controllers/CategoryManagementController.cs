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
    public class CategoryManagementController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryManagementController(ICategoryService categoryServices)
        {
            _categoryService = categoryServices;
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

            Expression<Func<Category, bool>> filter = null;
            Func<IQueryable<Category>, IOrderedQueryable<Category>> orderBy = null;

            if (searchString.IsNotBlank())
            {
                filter = a => a.CategoryName.Contains(searchString);
            }
            switch (sortOrder)
            {
                case "name_desc":
                    orderBy = b => b.OrderByDescending(s => s.CategoryName);
                    break;
                case "Total":
                    orderBy = b => b.OrderBy(s => s.Books.Count());
                    break;
                case "total_desc":
                    orderBy = b => b.OrderByDescending(s => s.Books.Count());
                    break;
                default:
                    orderBy = b => b.OrderBy(s => s.CategoryName);
                    break;
            }

            var categories = await _categoryService.GetAsync(filter: filter, orderBy: orderBy, page: page ?? 1, pageSize: 10);

            return View(categories);
        }

        public ActionResult AddCategory()
        {
            var categoryEditViewModel = new CategoryEditViewModel();
            return View(categoryEditViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult AddCategory(CategoryEditViewModel categoryEditViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(categoryEditViewModel);
            }

            var category = Mapper.Map<Category>(categoryEditViewModel);

            _categoryService.Create(category);

            return RedirectToAction("Index");
        }

        public ActionResult EditCategory(int id)
        {
            var category = _categoryService.GetById(id);

            var categoryEditViewModel = Mapper.Map<CategoryEditViewModel>(category);

            return View(categoryEditViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult EditCategory(CategoryEditViewModel categoryEditViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(categoryEditViewModel);
            }

            var category = Mapper.Map<Category>(categoryEditViewModel);
            _categoryService.Update(category);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteCategory(int id)
        {
            _categoryService.Delete(id);

            return RedirectToAction("Index");
        }

        [AcceptVerbs("Get", "Post")]
        public ActionResult CheckIfCategoryNameAlreadyExists([Bind(Prefix = "Category.CategoryName")]string name)
        {
            var category = _categoryService.Find(b => b.CategoryName == name);
            return category == null ? Json(true) : Json("Category name exists");
        }
    }
}