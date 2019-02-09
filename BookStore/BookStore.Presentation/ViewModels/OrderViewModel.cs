using System.ComponentModel.DataAnnotations;

namespace BookStore.Presentation.ViewModels
{
    public class OrderViewModel
    {
        [Required(ErrorMessage = "Please enter your full name.")]
        [StringLength(30, ErrorMessage = "The full name must be between 3 and 30 characters.", MinimumLength = 3)]
        [Display(Name = "Ship Name")]
        public string ShipName { get; set; }

        [Required(ErrorMessage = "Please enter your ship address.")]
        [StringLength(150, ErrorMessage = "The ship address must be between 5 and 150 characters.", MinimumLength = 5)]
        [Display(Name = "Ship Address")]
        public string ShipAddress { get; set; }

        [Required(ErrorMessage = "Please enter ship city.")]
        [StringLength(100, ErrorMessage = "The ship city name must be between 3 and 30 characters.", MinimumLength = 3)]
        [Display(Name = "Ship City")]
        public string ShipCity { get; set; }

        [Required(ErrorMessage = "Please enter phone number.")]
        [StringLength(10, ErrorMessage = "The phone number must be 10 characters.", MinimumLength = 10)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }
}