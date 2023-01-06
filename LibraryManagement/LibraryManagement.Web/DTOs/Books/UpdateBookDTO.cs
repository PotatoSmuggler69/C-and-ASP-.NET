using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Web.DTOs.Books
{
    public class UpdateBookDTO
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string BookName { get; set; } = String.Empty;
        
        [Required]
        [RegularExpression(@"^[A-Za-z][A-Za-z ]*[A-Za-z]$", ErrorMessage = "Only Alphabets and space allowed")]
        public string Author { get; set; } = String.Empty;
        [Required]
        public int Price { get; set; } = 0;

        public string genre { get; set; } = String.Empty;
    }
}
