using BookStore.Models;
using System.Collections.Generic;

namespace BookStore.Presentation.ViewModels
{
    public class BooksListViewModel
    {
        public IEnumerable<Book> Books { get; set; }
        public string CurrentCategory { get; set; }
    }
}
