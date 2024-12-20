using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookingSampleApp_V1.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        public string Title { get; set; }
        public string Generation { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        [DisplayName("Publish Year")]
        public int PublishYear { get; set; }

        public float Price { get; set; }

        public int IsActive { get; set; }
    }
}
