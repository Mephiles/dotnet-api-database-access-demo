using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DatabaseAccessDemo.Models;

public partial class ApiDbContext : DbContext
{
    public ApiDbContext()
    {
    }

    public ApiDbContext(DbContextOptions<ApiDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Type> Types { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DemoAPI");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__item__3213E83F971CC055");

            entity.ToTable("item");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Type)
                .HasMaxLength(1)
                .HasColumnName("type");

            entity.HasOne(d => d.TypeNavigation).WithMany(p => p.Items)
                .HasForeignKey(d => d.Type)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__item__type__4222D4EF");
        });

        modelBuilder.Entity<Type>(entity =>
        {
            entity.HasKey(e => e.Name).HasName("PK__type__72E12F1A822D0BF5");

            entity.ToTable("type");

            entity.Property(e => e.Name)
                .HasMaxLength(1)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
