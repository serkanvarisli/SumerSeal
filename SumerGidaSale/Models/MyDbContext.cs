using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SumerGidaSale.Models;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-R44CUI4\\MSSQLSERVER05;Database=SumerSaleDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Sale>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Sale");

            entity.Property(e => e.CustomerCode).IsUnicode(false);
            entity.Property(e => e.CustomerTitle).IsUnicode(false);
            entity.Property(e => e.District).IsUnicode(false);
            entity.Property(e => e.Province).IsUnicode(false);
            entity.Property(e => e.SaleQuentity).IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("User");

            entity.Property(e => e.Password).IsUnicode(false);
            entity.Property(e => e.Username).IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
