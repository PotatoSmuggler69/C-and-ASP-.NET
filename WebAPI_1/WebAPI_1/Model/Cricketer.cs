using System.ComponentModel.DataAnnotations;

namespace WebAPI_1.Model
{
    public class Cricketer
    {
        public int ID { get; set; }
        
        [Required]
        public String Name { get; set; }
       
        [Required]
        public String country { get; set; }

        [Required]
        [Range(10, 100,ErrorMessage ="Enter a valid age")]
        public int age { get; set; }



    }
}
