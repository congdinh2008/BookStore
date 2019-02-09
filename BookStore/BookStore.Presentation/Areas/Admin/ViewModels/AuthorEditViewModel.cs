using BookStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.Presentation.Areas.Admin.ViewModels
{
    public class AuthorEditViewModel
    {
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "Please enter author name.")]
        [MaxLength(50, ErrorMessage = "The name must be between 3 and 50 characters.")]
        [MinLength(3, ErrorMessage = "The name must be between 3 and 50 characters.")]
        [Display(Name = "Author Name")]
        public string AuthorName { get; set; }

        [Required(ErrorMessage = "Please enter author description.")]
        [MaxLength(1000, ErrorMessage = "The description must be between 20 and 1000 characters.")]
        [MinLength(20, ErrorMessage = "The description must be between 20 and 1000 characters.")]
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}