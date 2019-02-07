using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    public class Publisher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PublisherId { get; set; }

        [Required(ErrorMessage = "Please enter publisher name.")]
        [StringLength(50, ErrorMessage = "The publisher name must be between 3 and 50 characters.", MinimumLength = 3)]
        [Display(Name = "Publisher Name")]
        public string PublisherName { get; set; }

        [Required(ErrorMessage = "Please enter publisher description.")]
        [StringLength(1000, ErrorMessage = "The publisher description must be between 20 and 1000 characters.", MinimumLength = 20)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}