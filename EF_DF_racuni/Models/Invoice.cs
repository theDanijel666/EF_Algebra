using System;
using System.Collections.Generic;

namespace EF_DF_racuni.Models;

public partial class Invoice
{
    public int InvoiceNumber { get; set; }

    public DateTime DateOfIssue { get; set; }

    public virtual ICollection<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();
}
