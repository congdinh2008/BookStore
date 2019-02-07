namespace BookStore.Presentation.ViewModels
{
    public class BookEditViewModel
    {
        public string Title { get; set; }

        public string Summary { get; set; }

        public string ImgUrl { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public bool IsActive { get; set; }

        public int CategoryId { get; set; }

        public int AuthorId { get; set; }

        public int PublisherId { get; set; }
    }
}