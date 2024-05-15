using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EF_Migracije.Models
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

        [Range(1, 5)]
        public double? Ocjena { get; set; }
    }
}
