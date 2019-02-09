using System;

namespace BookStore.Presentation.ViewModels
{
    public class BookViewModel
    {
        public int BookId { get; set; }

        public string Title { get; set; }

        public string Summary { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        public DateTimeOffset ModifiedDate { get; set; }

        public int Quantity { get; set; }

        public bool IsActive { get; set; }

        public int CategoryId { get; set; }

        public CategoryViewModel Category { get; set; }

        public int AuthorId { get; set; }

        public AuthorViewModel Author { get; set; }

        public int PublisherId { get; set; }

        public PublisherViewModel Publisher { get; set; }
    }
}