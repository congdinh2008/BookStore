using BookStore.BusinessLogicLayer;
using BookStore.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private IBookService _bookServices;

        public HomeController(IBookService bookServices)
        {
            _bookServices = bookServices;
        }
        public async Task<ActionResult> Index()
        {
            var books = await _bookServices.GetAsync(filter: b => b.IsActive == true, orderBy: b => b.OrderBy(x => x.Title), page: 1, pageSize: 12);

            return View(books);
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