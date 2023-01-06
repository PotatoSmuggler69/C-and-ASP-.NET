using System.ComponentModel.DataAnnotations;

namespace Univ.web.Models
{
    public class Food
    {
        [Key]
        public String FoodName { get; set; } = String.Empty;
        public String Origin { get; set; } = String.Empty;

        public int Price { get; set; } = 0;
    }
}
