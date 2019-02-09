using BookStore.Models;
using System.Collections.Generic;

namespace BookStore.Presentation.ViewModels
{
    public class BooksListByAuthorViewModel
    {
        public IEnumerable<Book> Books { get; set; }
        public string CurrentAuthor { get; set; }
    }
}
