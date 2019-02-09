using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Presentation.ViewModels
{
    public class EditRoleViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter role name")]
        [MaxLength(20, ErrorMessage = "The role name must be between 3 and 20 characters.")]
        [MinLength(3, ErrorMessage = "The role name must be between 3 and 20 characters.")]
        [Display(Name = "Role name")]
        public string Name { get; set; }

        public List<string> Users { get; set; }
    }
}
