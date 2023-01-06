using LibraryManager.web.Models.Roles;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations;

namespace LibraryManager.web.Models
{
    public class Users
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage ="Username is required")]
        [Display(Name = "Username")]
        [RegularExpression(@"[A-Za-z0-9_]",ErrorMessage ="Only Alphabets, Numbers, Underscore(_) are accepted")]
        public String Username { get; set; } = String.Empty;

        [Required(ErrorMessage = "Username is required")]
        [Display(Name = "Full Name")]
        [RegularExpression(@"^[A-Za-z][A-Za-z ]*[A-Za-z]$", ErrorMessage = "Only Alphabets and space allowed")]
        public String Name { get; set; } = "Andrew Tate";


        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; } = String.Empty;

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Enter Valid Phone Number")]
        [Phone]
        public string PhoneNumber { get; set; } = String.Empty;

        public EmpRole Job { get; set; } = EmpRole.Student;  
    }
}
