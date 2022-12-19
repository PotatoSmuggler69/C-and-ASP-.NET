using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Portfolio_Website.Models
{
    
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        public string? full_name { get; set; }

        public string? EmailAddress { get; set; }

        public long? Phone { get; set; }

        public String? Description { get; set; }

        public DateTime? DOA { get; set; }

    }
}
