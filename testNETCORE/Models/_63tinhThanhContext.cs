using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace testNETCORE.Models;

public partial class _63tinhThanhContext : DbContext
{
    public _63tinhThanhContext()
    {
    }

    public _63tinhThanhContext(DbContextOptions<_63tinhThanhContext> options)
        : base(options)
    {
    }

    public virtual DbSet<LichSuTimKiem> LichSuTimKiems { get; set; }

    public virtual DbSet<NavigationBar> NavigationBars { get; set; }

    public virtual DbSet<Tinh> Tinhs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-ARKQSHH1\\KTEAM;Initial Catalog=63TinhThanh;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False\n");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LichSuTimKiem>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("LichSuTimKiem");

            entity.Property(e => e.Destination).HasMaxLength(100);
        });

        modelBuilder.Entity<NavigationBar>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Navigation_Bar");

            entity.Property(e => e.IdMenu).HasColumnName("ID_Menu");
            entity.Property(e => e.Link).HasMaxLength(255);
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<Tinh>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Tinh");

            entity.Property(e => e.Province).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
