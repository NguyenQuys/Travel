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

    public virtual DbSet<CamNangDuLich> CamNangDuLiches { get; set; }

    public virtual DbSet<LichSuTimKiem> LichSuTimKiems { get; set; }

    public virtual DbSet<NavigationBar> NavigationBars { get; set; }

    public virtual DbSet<Tinh> Tinhs { get; set; }

    public virtual DbSet<Tour> Tours { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-ARKQSHH1\\KTEAM;Initial Catalog=63TinhThanh;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CamNangDuLich>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Cam_Nang_Du_Lich");

            entity.Property(e => e.CoverImage)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Cover_Image");
            entity.Property(e => e.Link)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.TravelGuideId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("Travel_Guide_ID");
            entity.Property(e => e.TravelGuideTitleTitle)
                .HasMaxLength(250)
                .HasColumnName("Travel_Guide_Title_Title");
        });

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

        modelBuilder.Entity<Tour>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Tour");

            entity.Property(e => e.Departure).HasMaxLength(50);
            entity.Property(e => e.Description).HasColumnType("ntext");
            entity.Property(e => e.Destination1)
                .HasMaxLength(50)
                .HasColumnName("Destination_1");
            entity.Property(e => e.Destination2)
                .HasMaxLength(50)
                .HasColumnName("Destination_2");
            entity.Property(e => e.Destination3)
                .HasMaxLength(50)
                .HasColumnName("Destination_3");
            entity.Property(e => e.EndDate).HasColumnName("End_Date");
            entity.Property(e => e.Idcategory).HasColumnName("IDCategory");
            entity.Property(e => e.Image1)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Image_1");
            entity.Property(e => e.Image2)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Image_2");
            entity.Property(e => e.Image3)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Image_3");
            entity.Property(e => e.JourneyHightlight)
                .HasColumnType("ntext")
                .HasColumnName("Journey_Hightlight");
            entity.Property(e => e.Link)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.NdaysNnights)
                .HasMaxLength(20)
                .HasColumnName("NDaysNNights");
            entity.Property(e => e.PriceForAdult).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.PriceForChildren).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.StartDate).HasColumnName("Start_Date");
            entity.Property(e => e.TourId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("Tour_ID");
            entity.Property(e => e.TourName)
                .HasMaxLength(250)
                .HasColumnName("Tour_Name");
            entity.Property(e => e.TravelingSchedule)
                .HasColumnType("ntext")
                .HasColumnName("Traveling_Schedule");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__User__ED4DE442FF813A0B");

            entity.ToTable("User");

            entity.Property(e => e.IdUser).HasColumnName("ID_User");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber).HasColumnType("numeric(10, 0)");
            entity.Property(e => e.UserName)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
