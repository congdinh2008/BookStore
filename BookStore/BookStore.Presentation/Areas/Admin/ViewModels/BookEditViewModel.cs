using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Presentation.Areas.Admin.ViewModels
{
    public class BookEditViewModel
    {
        public int BookId { get; set; }

        [Required(ErrorMessage = "Please enter book title.")]
        [Display(Name = "Title")]
        [MaxLength(200, ErrorMessage = "The review must be between 3 and 200 characters.")]
        [MinLength(3, ErrorMessage = "The review must be between 3 and 200 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter book summary.")]
        [Display(Name = "Summary")]
        [MaxLength(2000, ErrorMessage = "The summary must be between 20 and 2000 characters.")]
        [MinLength(20, ErrorMessage = "The summary must be between 20 and 2000 characters.")]
        public string Summary { get; set; }

        [Required(ErrorMessage = "Please enter book image path.")]
        [Display(Name = "Image Thumbnail")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Please enter book price")]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Display(Name = "Quantity")]
        [DefaultValue(0)]
        public int Quantity { get; set; }

        [Display(Name = "Is Active?")]
        [DefaultValue(false)]
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "Please select a category")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Please select an author")]
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "Please select a publisher")]
        public int PublisherId { get; set; }
    }
}
