using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EF_Migracije.Models
{
    public class Book
    {
        [Key]
        [DisplayName("Šifra knjige")]
        public int ID { get; set; }

        [DisplayName("Naslov")]
        public string Title { get; set; }

        [DisplayName("Kratki opis")]
        public string Description { get; set; }

        [DisplayName("Žanr")]
        public string Genre { get; set; }

        [DisplayName("Na zalihi")]
        public int Stock { get; set; }

        [DisplayName("Datum izdavanja")]
        public DateTime ReleaseDate { get; set; }

        [DisplayName("Autor")]
        [ForeignKey("AuthorId")]
        public Author Author { get; set; }
        public int AuthorId { get; set; }
    }
}
