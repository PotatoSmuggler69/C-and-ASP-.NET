using System.ComponentModel.DataAnnotations;
using UnivManagement.web.Models.Roles;

namespace UnivManagement.web.Models
{
    public class PeopleInfo
    {
        [Key]
        [EmailAddress(ErrorMessage = "Enter a valid Email")]
        public String Email { get; set; } = "email@example.com";

        public String FullName { get; set; } = String.Empty;

        [Phone]
        public String phone { get; set; } = String.Empty;

        public PeopleRoles Role { get; set; } = PeopleRoles.Student;
    }
}
