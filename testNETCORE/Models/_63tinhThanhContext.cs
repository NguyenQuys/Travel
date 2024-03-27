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

    public virtual DbSet<Tinh> Tinhs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-ARKQSHH1\\KTEAM;Initial Catalog=63TinhThanh;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LichSuTimKiem>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("LichSuTimKiem");

            entity.Property(e => e.Destination).HasMaxLength(100);
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
