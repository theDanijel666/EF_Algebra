using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EF_DF_books.Models;

public partial class CfBookStoreContext : DbContext
{
    public CfBookStoreContext()
    {
    }

    public CfBookStoreContext(DbContextOptions<CfBookStoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:Bookstore");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.ToTable("Author");

            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.ToTable("Book");

            entity.HasIndex(e => e.AuthorId, "IX_Book_AuthorId");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.HasOne(d => d.Author).WithMany(p => p.Books).HasForeignKey(d => d.AuthorId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
