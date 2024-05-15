using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EF_DF_racuni.Models;

public partial class InvoicesContext : DbContext
{
    public InvoicesContext()
    {
    }

    public InvoicesContext(DbContextOptions<InvoicesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<InvoiceItem> InvoiceItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:Invoices");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.InvoiceNumber).HasName("PK__Invoices__D776E980B7BC01DE");

            entity.Property(e => e.DateOfIssue).HasColumnType("datetime");
        });

        modelBuilder.Entity<InvoiceItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__InvoiceI__3214EC27F93F4EF3");

            entity.ToTable("InvoiceItem");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Quantity).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Title).HasMaxLength(255);

            entity.HasOne(d => d.InvoiceNumberNavigation).WithMany(p => p.InvoiceItems)
                .HasForeignKey(d => d.InvoiceNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__InvoiceIt__Invoi__38996AB5");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
