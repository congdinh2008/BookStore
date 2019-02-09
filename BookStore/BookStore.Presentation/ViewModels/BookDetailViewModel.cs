using BookStore.Models;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Presentation.ViewModels
{
    public class BookDetailViewModel
    {
        public Book Book { get; set; }

        [Required]
        [MaxLength(500, ErrorMessage = "The review must be between 20 and 500 characters.")]
        [MinLength(20, ErrorMessage = "The review must be between 20 and 500 characters.")]
        public string Review { get; set; }
    }
}
