using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EF_CF_books.Models
{
    public class Author
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [DisplayName("Autor")]
        public string Name { get; set; }

        [DisplayName("Biografija")]
        public string? Bio { get; set; }

        [Range(1,5)]
        public double? Ocjena { get; set; }
    }
}
