using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Web.DTOs.Auth
{
    public class RegisterDTO
    {
        [Key]
        public int MemberId { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-z][A-Za-z ]*[A-Za-z]$", ErrorMessage = "Only Alphabets and space allowed")]
        public string Name { get; set; } = String.Empty;

        [Required]
        public string Password { get; set; } = String.Empty;
 
    }
}
