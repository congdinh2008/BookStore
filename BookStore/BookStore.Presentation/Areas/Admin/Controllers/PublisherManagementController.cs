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
    public class PublisherManagementController : Controller
    {
        private readonly IPublisherService _publisherServices;

        public PublisherManagementController(IPublisherService publisherServices)
        {
            _publisherServices = publisherServices;
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

            Expression<Func<Publisher, bool>> filter = null;
            Func<IQueryable<Publisher>, IOrderedQueryable<Publisher>> orderBy = null;

            if (searchString.IsNotBlank())
            {
                filter = a => a.PublisherName.Contains(searchString);
            }
            switch (sortOrder)
            {
                case "name_desc":
                    orderBy = b => b.OrderByDescending(s => s.PublisherName);
                    break;
                case "Total":
                    orderBy = b => b.OrderBy(s => s.Books.Count());
                    break;
                case "total_desc":
                    orderBy = b => b.OrderByDescending(s => s.Books.Count());
                    break;
                default:
                    orderBy = b => b.OrderBy(s => s.PublisherName);
                    break;
            }

            var publishers = await _publisherServices.GetAsync(filter: filter, orderBy: orderBy, page: page ?? 1, pageSize: 10);

            return View(publishers);
        }

        public ActionResult AddPublisher()
        {
            var publisherEditViewModel = new PublisherEditViewModel();
            return View(publisherEditViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult AddPublisher(PublisherEditViewModel publisherEditViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(publisherEditViewModel);
            }

            var publisher = Mapper.Map<Publisher>(publisherEditViewModel);

            _publisherServices.Create(publisher);

            return RedirectToAction("Index");
        }

        public ActionResult EditPublisher(int id)
        {
            var publisher = _publisherServices.GetById(id);

            var publisherEditViewModel = Mapper.Map<PublisherEditViewModel>(publisher);

            return View(publisherEditViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult EditPublisher(PublisherEditViewModel publisherEditViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(publisherEditViewModel);
            }

            var publisher = Mapper.Map<Publisher>(publisherEditViewModel);
            _publisherServices.Update(publisher);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeletePublisher(int id)
        {
            _publisherServices.Delete(id);

            return RedirectToAction("Index");
        }

        [AcceptVerbs("Get", "Post")]
        public ActionResult CheckIfPublisherNameAlreadyExists([Bind(Prefix = "Publisher.PublisherName")]string name)
        {
            var publisher = _publisherServices.Find(b => b.PublisherName == name);
            return publisher == null ? Json(true) : Json("Publisher name is exists");
        }
    }
}