using BookStore.Models;
using System.Collections.Generic;

namespace BookStore.Presentation.ViewModels
{
    public class BooksListByPriceViewModel
    {
        public IEnumerable<Book> Books { get; set; }
        public decimal CurrentPrice { get; set; }
    }
}
