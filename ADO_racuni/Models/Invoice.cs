using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ADO_racuni.Models
{
    public class Invoice
    {
        [DisplayName("Broj računa")]
        public int InvoiceNumber { get; set; }

        [DisplayName("Datum izdavanja")]
        [DisplayFormat(DataFormatString ="{0:dd MMM yyy}")]
        public DateTime DateOfIssue { get; set; }

        public List<InvoiceItem> InvoiceItems { get; set; }

        public Invoice()
        {
            InvoiceItems = new List<InvoiceItem>();
        }

        public decimal InvoiceTotal()
        {
            decimal total = 0;
            foreach(var item in InvoiceItems)
            {
                total += item.InvoiceItemTotal();
            }
            return total;
        }
    }
}
