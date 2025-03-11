using System;
using System.Collections.Generic;
using ecommerce.Areas.Admin.Models;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.Models;

public partial class EcommerceDbContext : DbContext
{
    public EcommerceDbContext()
    {
    }

    public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<category> categories { get; set; }

    public virtual DbSet<order> orders { get; set; }

    public virtual DbSet<product> products { get; set; }

    public virtual DbSet<product_category> product_categories { get; set; }

    public virtual DbSet<user> users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=AYLIN;Database=ecommerce;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<category>(entity =>
        {
            entity.HasKey(e => e.category_id);

            entity.ToTable("category");

            entity.Property(e => e.create_date).HasColumnType("datetime");
            entity.Property(e => e.update_date).HasColumnType("datetime");
        });

        modelBuilder.Entity<order>(entity =>
        {
            entity.HasKey(e => e.order_id);

            entity.ToTable("order");

            entity.Property(e => e.create_date).HasColumnType("datetime");
            entity.Property(e => e.delivery_adress).HasColumnType("text");
            entity.Property(e => e.order_date).HasColumnType("datetime");
            entity.Property(e => e.order_status).HasMaxLength(20);
            entity.Property(e => e.payment_date).HasColumnType("datetime");
            entity.Property(e => e.payment_status).HasMaxLength(50);
            entity.Property(e => e.total_amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.update_date).HasColumnType("datetime");
            entity.Property(e => e.upload_date).HasColumnType("datetime");
        });

        modelBuilder.Entity<product>(entity =>
        {
            entity.ToTable("product");

            entity.Property(e => e.color).HasMaxLength(50);
            entity.Property(e => e.create_date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.image_url).HasMaxLength(500);
            entity.Property(e => e.name).HasMaxLength(250);
            entity.Property(e => e.price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.rating)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(3, 2)");
            entity.Property(e => e.size).HasMaxLength(50);
            entity.Property(e => e.sku).HasMaxLength(50);
            entity.Property(e => e.update_date).HasColumnType("datetime");
        });

        modelBuilder.Entity<product_category>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK_productCategory");

            entity.ToTable("product_category");

            entity.Property(e => e.create_date).HasColumnType("datetime");
            entity.Property(e => e.description).HasMaxLength(200);
            entity.Property(e => e.name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.update_date).HasColumnType("datetime");
        });

        modelBuilder.Entity<user>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK_users");

            entity.ToTable("user");

            entity.Property(e => e.birth_date).HasColumnType("datetime");
            entity.Property(e => e.create_time)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.email).HasMaxLength(100);
            entity.Property(e => e.gender).HasMaxLength(10);
            entity.Property(e => e.name).HasMaxLength(100);
            entity.Property(e => e.password).HasMaxLength(200);
            entity.Property(e => e.phone_area).HasMaxLength(5);
            entity.Property(e => e.phone_number).HasMaxLength(10);
            entity.Property(e => e.surname).HasMaxLength(100);
            entity.Property(e => e.tckn).HasMaxLength(11);
            entity.Property(e => e.update_date).HasColumnType("datetime");
            entity.Property(e => e.vkn).HasMaxLength(10);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
