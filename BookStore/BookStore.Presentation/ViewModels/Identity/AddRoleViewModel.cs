using System.ComponentModel.DataAnnotations;

namespace BookStore.Presentation.ViewModels
{
    public class AddRoleViewModel
    {
        [Required]
        [MaxLength(20, ErrorMessage = "The role name must be between 3 and 20 characters.")]
        [MinLength(3, ErrorMessage = "The role name must be between 3 and 20 characters.")]
        [Display(Name = "Role Name")]
        public string Name { get; set; }
    }
}
