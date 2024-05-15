using System;
using System.Collections.Generic;

namespace EF_DF_books.Models;

public partial class Author
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Bio { get; set; }

    public double? Ocjena { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
