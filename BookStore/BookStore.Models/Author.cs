using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    public class Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "Please enter author name.")]
        [StringLength(50, ErrorMessage = "The author name must be between 3 and 50 characters.", MinimumLength = 3)]
        [Display(Name = "Author Name")]
        public string AuthorName { get; set; }

        [Required(ErrorMessage = "Please enter author description.")]
        [StringLength(1000, ErrorMessage = "The author description must be between 20 and 1000 characters.", MinimumLength = 20)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}