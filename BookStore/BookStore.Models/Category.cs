using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Please enter category name.")]
        [StringLength(50, ErrorMessage = "The category name must be between 3 and 50 characters.", MinimumLength = 3)]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "Please enter category description.")]
        [StringLength(1000, ErrorMessage = "The category description must be between 20 and 1000 characters.", MinimumLength = 20)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
