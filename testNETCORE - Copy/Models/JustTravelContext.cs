using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace testNETCORE.Models;

public partial class JustTravelContext : DbContext
{
    public JustTravelContext()
    {
    }

    public JustTravelContext(DbContextOptions<JustTravelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<CountryCity> CountryCities { get; set; }

    public virtual DbSet<Discount> Discounts { get; set; }

    public virtual DbSet<InvoiceDetail> InvoiceDetails { get; set; }

    public virtual DbSet<Like> Likes { get; set; }

    public virtual DbSet<NavigationBar> NavigationBars { get; set; }

    public virtual DbSet<SearchHistory> SearchHistories { get; set; }

    public virtual DbSet<Statistical> Statisticals { get; set; }

    public virtual DbSet<Tinh> Tinhs { get; set; }

    public virtual DbSet<Tour> Tours { get; set; }

    public virtual DbSet<TravelGuide> TravelGuides { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-ARKQSHH1\\KTEAM;Initial Catalog=Just_Travel;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Idcategory).HasName("PK__Categori__6DB3A68A0405C12A");

            entity.Property(e => e.Idcategory)
                .ValueGeneratedNever()
                .HasColumnName("ID_Category");
            entity.Property(e => e.CategoryName).HasMaxLength(255);
            entity.Property(e => e.Link).HasMaxLength(255);
        });

        modelBuilder.Entity<CountryCity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Country___3214EC27F08A2066");

            entity.ToTable("Country_Cities");

            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Discount>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Discount");

            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.IdDiscount)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID_Discount");
        });

        modelBuilder.Entity<InvoiceDetail>(entity =>
        {
            entity.HasKey(e => e.IdInvoice).HasName("PK__InvoiceD__0540CA604785406E");

            entity.Property(e => e.IdInvoice)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ID_Invoice");
            entity.Property(e => e.IdTour)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ID_Tour");
            entity.Property(e => e.IdUser).HasColumnName("ID_User");
            entity.Property(e => e.InvoiceDate).HasColumnType("datetime");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.StaticsticDate).HasColumnType("datetime");

            entity.HasOne(d => d.IdTourNavigation).WithMany(p => p.InvoiceDetails)
                .HasForeignKey(d => d.IdTour)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InvoiceDetails_Tour");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.InvoiceDetails)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__InvoiceDe__ID_Us__4D94879B");

            entity.HasOne(d => d.StaticsticDateNavigation).WithMany(p => p.InvoiceDetails)
                .HasForeignKey(d => d.StaticsticDate)
                .HasConstraintName("FK__InvoiceDe__Creat__4BAC3F29");
        });

        modelBuilder.Entity<Like>(entity =>
        {
            entity.HasKey(e => e.IdCart).HasName("PK__Like__72140ECF98CDAB72");

            entity.ToTable("Like");

            entity.Property(e => e.IdCart).HasColumnName("ID_Cart");
            entity.Property(e => e.IdTour)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ID_Tour");
            entity.Property(e => e.IdUser).HasColumnName("ID_User");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Likes)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Like__ID_UserI__4F7CD00D");
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

        modelBuilder.Entity<SearchHistory>(entity =>
        {
            entity.HasKey(e => e.IdSearch).HasName("PK__SearchHi__1BB97D065DD79A20");

            entity.ToTable("SearchHistory");

            entity.Property(e => e.IdSearch).HasColumnName("ID_Search");
            entity.Property(e => e.Content).HasMaxLength(255);
            entity.Property(e => e.IdUser).HasColumnName("ID_User");
            entity.Property(e => e.SearchDate).HasColumnType("datetime");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.SearchHistories)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SearchHis__ID_Us__5070F446");
        });

        modelBuilder.Entity<Statistical>(entity =>
        {
            entity.HasKey(e => e.CreatedDate).HasName("PK__Statisti__86A56E75B50EB986");

            entity.ToTable("Statistical");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.IdUser).HasColumnName("ID_User");
            entity.Property(e => e.TotalPrice)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Statisticals)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Statistic__ID_Us__5165187F");
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
            entity.HasKey(e => e.IdTour);

            entity.ToTable("Tour");

            entity.Property(e => e.IdTour)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ID_Tour");
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
                .IsUnicode(false);
            entity.Property(e => e.NdaysNnights)
                .HasMaxLength(20)
                .HasColumnName("NDaysNNights");
            entity.Property(e => e.PriceForAdult).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.PriceForChildren).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.StartDate).HasColumnName("Start_Date");
            entity.Property(e => e.TourName)
                .HasMaxLength(250)
                .HasColumnName("Tour_Name");
            entity.Property(e => e.TravelingSchedule)
                .HasColumnType("ntext")
                .HasColumnName("Traveling_Schedule");

            entity.HasOne(d => d.IdcategoryNavigation).WithMany(p => p.Tours)
                .HasForeignKey(d => d.Idcategory)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tour_Categories");
        });

        modelBuilder.Entity<TravelGuide>(entity =>
        {
            entity.HasKey(e => e.IdTravelGuide).HasName("PK__TravelGu__BC5EA68C0A7AB681");

            entity.ToTable("TravelGuide");

            entity.Property(e => e.IdTravelGuide)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ID_TravelGuide");
            entity.Property(e => e.Content).HasMaxLength(255);
            entity.Property(e => e.CoverImage)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Cover_Image");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Link).HasMaxLength(255);
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__User__B97FFDFB38522D60");

            entity.ToTable("User");

            entity.HasIndex(e => e.PhoneNumber, "UQ__User__85FB4E38470993A8").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__User__A9D105348EDC7728").IsUnique();

            entity.Property(e => e.IdUser).HasColumnName("ID_User");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.FullName).HasMaxLength(255);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(11)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
