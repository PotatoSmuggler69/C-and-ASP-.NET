using LibraryManagement.Web.Infrastructure.Roles;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Web.Models
{
    public class Member
    {
        [Key]
        public int MemberId { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        public string Name { get; set; } = String.Empty;
        [Required]
        public AppRole Role { get; set; } = AppRole.Member;
        public List<Book> BookTaken { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }
    }
}
