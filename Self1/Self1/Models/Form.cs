using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Self1.Models
{
    public class Form
    {
        public int id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string? LastName { get; set; }
        public int age { get; set; }

        [Display(Name = "Date of Birth")]
        
        public DateTime DOB { get; set; } = DateTime.Now;
    }
}
