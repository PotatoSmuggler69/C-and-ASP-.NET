using System.ComponentModel.DataAnnotations;


namespace CodeFirstApproach.Models
{
    public class WaraWow
    {
        [Key]
        public int Id { get; set; }
      
        public string? Book_name { get; set; }

        public string? Author { get; set; }
       
        public string? pages { get; set; }
        public int Count { get; set; }


    }
}
