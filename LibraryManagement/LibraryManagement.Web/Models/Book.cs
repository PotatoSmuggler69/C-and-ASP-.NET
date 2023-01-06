using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagement.Web.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string BookName { get; set; } = String.Empty;

        [Required]
        public string Author { get; set; } = String.Empty;
        [Required]
        public int Price { get; set; } = 0;

        public string genre { get; set; } = String.Empty;
        
        /*public DateTime IssuedDate { get; set; }
        public DateTime ReturnedDate { get; set; }*/

    }
}
