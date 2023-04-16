using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication007.DAL;

public partial class Core007Context : DbContext
{
    public Core007Context()
    {
    }

    public Core007Context(DbContextOptions<Core007Context> options)
        : base(options)
    {
    }

    public virtual DbSet<AppUser> AppUsers { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB; database=Core007; trusted_connection=true; trustservercertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AppUsers__3214EC071200B5A0");

            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.Gender).WithMany(p => p.AppUsers)
                .HasForeignKey(d => d.GenderId)
                .HasConstraintName("FK__AppUsers__Gender__4BAC3F29");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Genders__3214EC07AF1E8C5D");

            entity.Property(e => e.Text)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
