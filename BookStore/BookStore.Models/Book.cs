using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }

        [Required(ErrorMessage = "Please enter book title.")]
        [Display(Name = "Title")]
        [StringLength(200, ErrorMessage = "The review must be between 3 and 200 characters.", MinimumLength = 3)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter book summary.")]
        [Display(Name = "Summary")]
        [StringLength(2000, ErrorMessage = "The summary must be between 20 and 2000 characters.", MinimumLength = 20)]
        public string Summary { get; set; }

        [Required(ErrorMessage = "Please select book image.")]
        [Display(Name = "Image Thumbnail")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Please enter book price")]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Display(Name = "Quantity")]
        [DefaultValue(0)]
        public int Quantity { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Modified Date")]
        public DateTime ModifiedDate { get; set; }

        [Display(Name = "Is Active?")]
        [DefaultValue(false)]
        public bool IsActive { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }

        public int AuthorId { get; set; }

        [ForeignKey("AuthorID")]
        public virtual Author Author { get; set; }

        public int PublisherId { get; set; }

        [ForeignKey("PublisherID")]
        public virtual Publisher Publisher { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}