using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReviewId { get; set; }

        [Required(ErrorMessage = "Please enter your review content.")]
        [StringLength(500, ErrorMessage = "The review content must be between 10 and 500 characters.", MinimumLength = 10)]
        [Display(Name = "Review")]
        public string Comment { get; set; }

        [Display(Name = "Created Date")]
        public DateTimeOffset CreatedDate { get; set; }

        [Display(Name = "Modified Date")]
        public DateTimeOffset ModifiedDate { get; set; }

        [Display(Name = "Is Active?")]
        [DefaultValue(false)]
        public bool IsActive { get; set; }

        public int BookId { get; set; }

        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
    }
}