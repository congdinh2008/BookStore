using BookStore.Models;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Presentation.Areas.Admin.ViewModels
{
    public class PublisherEditViewModel
    {
        public int PublisherId { get; set; }

        [Required(ErrorMessage = "Please enter publisher name.")]
        [MaxLength(50, ErrorMessage = "The name must be between 3 and 50 characters.")]
        [MinLength(3, ErrorMessage = "The name must be between 3 and 50 characters.")]
        [Display(Name = "Publisher Name")]
        public string PublisherName { get; set; }

        [Required(ErrorMessage = "Please enter publisher description.")]
        [MaxLength(1000, ErrorMessage = "The description must be between 20 and 1000 characters.")]
        [MinLength(20, ErrorMessage = "The description must be between 20 and 1000 characters.")]
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}