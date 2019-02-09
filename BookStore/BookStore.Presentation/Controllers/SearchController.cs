using BookStore.BusinessLogicLayer;
using BookStore.Presentation.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Mvc;

namespace BookStore.Presentation.Controllers
{
    public class SearchController : Controller
    {
        private readonly ICategoryService _categoryServices;
        private readonly IAuthorService _authorServices;
        private readonly IPublisherService _publisherServices;

        public SearchController(
            ICategoryService categoryServices,
            IAuthorService authorServices,
            IPublisherService publisherServices)
        {
            _categoryServices = categoryServices;
            _authorServices = authorServices;
            _publisherServices = publisherServices;
        }

        public ActionResult CategorySearch()
        {
            var syncContext = SynchronizationContext.Current;
            SynchronizationContext.SetSynchronizationContext(null);
            var categories = _categoryServices.GetAsync(orderBy: c => c.OrderBy(x => x.CategoryName), page: 1, pageSize: 3).Result;
            SynchronizationContext.SetSynchronizationContext(syncContext);

            return PartialView(categories);
        }

        public ActionResult AuthorSearch()
        {
            var syncContext = SynchronizationContext.Current;
            SynchronizationContext.SetSynchronizationContext(null);
            var authors = _authorServices.GetAsync(orderBy: a => a.OrderBy(x => x.AuthorName)).Result;
            SynchronizationContext.SetSynchronizationContext(syncContext);
            return PartialView(authors);
        }

        public ActionResult PublisherSearch()
        {
            var syncContext = SynchronizationContext.Current;
            SynchronizationContext.SetSynchronizationContext(null);
            var publishers = _publisherServices.GetAsync(orderBy: p => p.OrderBy(x => x.PublisherName)).Result;
            SynchronizationContext.SetSynchronizationContext(syncContext);
            return PartialView(publishers);
        }

        public ActionResult PriceSearch()
        {
            var priceSearchItems = new List<PriceSearchItem>
            {
                new PriceSearchItem()
                {
                    DisplayValue = 100000,
                    ActionValue = 100000,

                },
                new PriceSearchItem()
                {
                    DisplayValue = 200000,
                    ActionValue = 200000,

                },
                new PriceSearchItem()
                {
                    DisplayValue = 500000,
                    ActionValue = 500000,

                },
                new PriceSearchItem()
                {
                    DisplayValue = 1000000,
                    ActionValue = 1000000,

                }
            };

            return PartialView(priceSearchItems);
        }
    }
}