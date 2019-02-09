using BookStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.Presentation.Areas.Admin.ViewModels
{
    public class CategoryEditViewModel
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Please enter category name.")]
        [MaxLength(50, ErrorMessage = "The category name must be between 3 and 50 characters.")]
        [MinLength(3, ErrorMessage = "The category name must be between 3 and 50 characters.")]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "Please enter category description.")]
        [MaxLength(1000, ErrorMessage = "The category description must be between 20 and 1000 characters.")]
        [MinLength(20, ErrorMessage = "The category description must be between 20 and 1000 characters.")]
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}