using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class ApplicationUser : IdentityUser<int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        [Required(ErrorMessage = "Please enter your full name.")]
        [StringLength(30, ErrorMessage = "The full name must be between 3 and 30 characters.", MinimumLength = 3)]
        [Display(Name = "Full Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your city.")]
        [StringLength(30, ErrorMessage = "The city name must be between 3 and 30 characters.", MinimumLength = 3)]
        [Display(Name = "City")]
        public string City { get; set; }

        [StringLength(100, ErrorMessage = "The address must be between 5 and 100 characters.", MinimumLength = 5)]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter your birth day.")]
        [Display(Name = "Birth Day")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Photo")]
        public string Photo { get; set; }

        public virtual List<Review> Reviews { get; set; }

        public override ICollection<CustomUserClaim> Claims { get; } = new List<CustomUserClaim>();

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser, int> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }

    public class CustomUserRole : IdentityUserRole<int>
    {
    }

    public class CustomUserClaim : IdentityUserClaim<int>
    {
    }

    public class CustomUserLogin : IdentityUserLogin<int>
    {
    }
}
