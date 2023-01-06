using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Web.DTOs.Books
{
    public class GetBookDTO
    {

        public int BookId { get; set; }

        public string BookName { get; set; } = String.Empty;

  
        public string Author { get; set; } = String.Empty;

        public string genre { get; set; } = String.Empty;
    }
}
