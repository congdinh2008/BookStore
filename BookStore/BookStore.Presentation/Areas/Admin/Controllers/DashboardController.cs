using BookStore.BusinessLogicLayer;
using BookStore.Presentation.Areas.Admin.ViewModels;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BookStore.Presentation.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrators, Manager")]
    public class DashboardController : Controller
    {
        private readonly IBookService _bookServices;
        private readonly IAuthorService _authorService;
        private readonly ICategoryService _categoryService;
        private readonly IPublisherService _publisherService;
        private readonly IReviewService _bookReviewService;

        public DashboardController(
            IBookService bookServices, 
            IAuthorService authorService,
            ICategoryService categoryService,
            IPublisherService publisherService,
            IReviewService bookReviewService
            )
        {
            _bookServices = bookServices;
            _authorService = authorService;
            _categoryService = categoryService;
            _publisherService = publisherService;
            _bookReviewService = bookReviewService;
        }
        public async Task<ActionResult> Index()
        {
            var dashboardViewModel = new DashboardViewModel()
            {
                TopBooksByPrice = await _bookServices.GetAsync(orderBy: x => x.OrderByDescending(b => b.Price), page: 1, pageSize: 3),
                TopCategoriesByBook = await _categoryService.GetAsync(orderBy: x => x.OrderByDescending(b => b.Books.Count), page: 1, pageSize: 3),
                TopAuthorsByBook = await _authorService.GetAsync(orderBy: x => x.OrderByDescending(b => b.Books.Count), page: 1, pageSize: 3),
                TopPublishersByBook = await _publisherService.GetAsync(orderBy: x => x.OrderByDescending(b => b.Books.Count), page: 1, pageSize: 3),
                TopBooksByComment = await _bookServices.GetAsync(orderBy: x => x.OrderByDescending(b => b.Reviews.Count), page: 1, pageSize: 3),
                TotalBooks = await _bookServices.CountAsync(),
                TotalCategories = await _categoryService.CountAsync(),
                TotalAuthors = await _authorService.CountAsync(),
                TotalPublishers = await _publisherService.CountAsync(),
                TotalComments = await _bookReviewService.CountAsync(),
            };

            return View(dashboardViewModel);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}