using System;
using System.Collections.Generic;

namespace EF_DF_books.Models;

public partial class Book
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Genre { get; set; } = null!;

    public int Stock { get; set; }

    public DateTime ReleaseDate { get; set; }

    public int AuthorId { get; set; }

    public virtual Author Author { get; set; } = null!;
}
