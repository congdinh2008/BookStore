using BookStore.Models;
using System.Collections.Generic;

namespace BookStore.Presentation.Areas.Admin.ViewModels
{
    public class DashboardViewModel
    {
        public IEnumerable<Book> TopBooksByPrice { get; set; }
        public IEnumerable<Category> TopCategoriesByBook { get; set; }
        public IEnumerable<Author> TopAuthorsByBook { get; set; }
        public IEnumerable<Publisher> TopPublishersByBook { get; set; }
        public IEnumerable<Book> TopBooksByComment { get; set; }
        public int TotalBooks { get; set; }
        public int TotalCategories { get; set; }
        public int TotalAuthors { get; set; }
        public int TotalPublishers { get; set; }
        public int TotalComments { get; set; }
    }
}