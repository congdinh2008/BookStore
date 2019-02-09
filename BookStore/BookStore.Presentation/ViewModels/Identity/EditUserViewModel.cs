using BookStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Presentation.ViewModels
{
    public class EditUserViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your full name.")]
        [MaxLength(30, ErrorMessage = "The full name must be between 3 and 30 characters.")]
        [MinLength(3, ErrorMessage = "The role name must be between 3 and 20 characters.")]
        [Display(Name = "Full name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your birth day.")]
        [Display(Name = "Birth Day")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Please enter your city.")]
        [MaxLength(100, ErrorMessage = "The city name must be between 3 and 30 characters.")]
        [MinLength(3, ErrorMessage = "The city name must be between 3 and 30 characters.")]
        [Display(Name = "City")]
        public string City { get; set; }

        [MaxLength(100, ErrorMessage = "The address must be between 5 and 100 characters.")]
        [MinLength(5, ErrorMessage = "The address must be between 5 and 100 characters.")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter your email address.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }

        public List<string> UserClaims { get; set; }
    }
}
