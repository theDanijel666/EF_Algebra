using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EF_Code_first.Models
{
    public class ToDoModel
    {
        [Key]
        public int ID { get; set; }

        [DisplayName("Zadatak")]
        public string Title { get; set; }

        public bool IsCompleted { get; set; } = false;

        public DateTime Dedline { get; set; }
    }
}
