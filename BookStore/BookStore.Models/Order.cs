using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

        [Display(Name = "Created Date")]
        public DateTimeOffset CreatedDate { get; set; }

        [Display(Name = "Modified Date")]
        public DateTimeOffset ModifiedDate { get; set; }

        [Display(Name ="Shipped Date")]
        public DateTimeOffset ShippedDate { get; set; }

        [Required(ErrorMessage ="Please enter your full name.")]
        [StringLength(30, ErrorMessage ="The ship name must be between 3 and 30 characters", MinimumLength =3)]
        [Display(Name ="Ship Name")]
        public string ShipName { get; set; }

        [Required(ErrorMessage = "Please enter your ship address.")]
        [StringLength(100, ErrorMessage = "The ship address must be between 20 and 100 characters", MinimumLength = 20)]
        [Display(Name = "Ship Address")]
        public string ShipAddress { get; set; }

        [Required(ErrorMessage = "Please enter your ship city.")]
        [StringLength(50, ErrorMessage = "The ship city must be between 5 and 50 characters", MinimumLength = 5)]
        [Display(Name = "Ship City")]
        public string ShipCity { get; set; }

        [Required(ErrorMessage = "Please enter your phone number.")]
        [StringLength(10, ErrorMessage = "The phone number must be 10 characters", MinimumLength = 10)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
