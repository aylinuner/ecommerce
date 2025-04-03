using System;
using System.Collections.Generic;
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

    public virtual DbSet<basket> baskets { get; set; }

    public virtual DbSet<brand> brands { get; set; }

    public virtual DbSet<category> categories { get; set; }

    public virtual DbSet<city> cities { get; set; }

    public virtual DbSet<company> companies { get; set; }

    public virtual DbSet<customer> customers { get; set; }

    public virtual DbSet<district> districts { get; set; }

    public virtual DbSet<entry_detail> entry_details { get; set; }

    public virtual DbSet<entry_master> entry_masters { get; set; }

    public virtual DbSet<home> homes { get; set; }

    public virtual DbSet<order> orders { get; set; }

    public virtual DbSet<product> products { get; set; }

    public virtual DbSet<stock_movement> stock_movements { get; set; }

    public virtual DbSet<user> users { get; set; }

    public virtual DbSet<user_address> user_addresses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=AYLIN;Database=ecommerce;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<basket>(entity =>
        {
            entity.ToTable("basket");

            entity.Property(e => e.create_date).HasColumnType("datetime");
            entity.Property(e => e.uptade_date).HasColumnType("datetime");

            entity.HasOne(d => d.product).WithMany(p => p.baskets)
                .HasForeignKey(d => d.product_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_basket_product");

            entity.HasOne(d => d.user).WithMany(p => p.baskets)
                .HasForeignKey(d => d.user_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_basket_user");
        });

        modelBuilder.Entity<brand>(entity =>
        {
            entity.ToTable("brand");

            entity.Property(e => e.create_date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.name).HasMaxLength(50);
            entity.Property(e => e.update_time).HasColumnType("datetime");
        });

        modelBuilder.Entity<category>(entity =>
        {
            entity.ToTable("category");

            entity.Property(e => e.create_date).HasColumnType("datetime");
            entity.Property(e => e.name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.update_date).HasColumnType("datetime");
        });

        modelBuilder.Entity<city>(entity =>
        {
            entity.ToTable("city");

            entity.Property(e => e.id).HasMaxLength(3);
            entity.Property(e => e.create_date).HasColumnType("datetime");
            entity.Property(e => e.name).HasMaxLength(50);
            entity.Property(e => e.update_date).HasColumnType("datetime");
        });

        modelBuilder.Entity<company>(entity =>
        {
            entity.ToTable("company");

            entity.Property(e => e.create_date).HasColumnType("datetime");
            entity.Property(e => e.name).HasMaxLength(100);
            entity.Property(e => e.uptade_date).HasColumnType("datetime");
            entity.Property(e => e.vkn).HasMaxLength(10);
        });

        modelBuilder.Entity<customer>(entity =>
        {
            entity.ToTable("customer");

            entity.Property(e => e.birth_date).HasColumnType("datetime");
            entity.Property(e => e.create_date).HasColumnType("datetime");
            entity.Property(e => e.gender).HasMaxLength(50);
            entity.Property(e => e.name).HasMaxLength(100);
            entity.Property(e => e.phone_number).HasMaxLength(11);
            entity.Property(e => e.save_date).HasColumnType("datetime");
            entity.Property(e => e.surname).HasMaxLength(100);
            entity.Property(e => e.tckn).HasMaxLength(11);
            entity.Property(e => e.type).HasMaxLength(10);
            entity.Property(e => e.update__date)
                .HasColumnType("datetime")
                .HasColumnName("update_ date");
            entity.Property(e => e.vkn).HasMaxLength(10);

            entity.HasOne(d => d.user).WithMany(p => p.customers)
                .HasForeignKey(d => d.user_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_customer_user");
        });

        modelBuilder.Entity<district>(entity =>
        {
            entity.ToTable("district");

            entity.Property(e => e.id).HasMaxLength(10);
            entity.Property(e => e.create_date).HasColumnType("datetime");
            entity.Property(e => e.name).HasMaxLength(100);
            entity.Property(e => e.update_date).HasColumnType("datetime");
        });

        modelBuilder.Entity<entry_detail>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK_entry_detail_1");

            entity.ToTable("entry_detail");

            entity.Property(e => e.create_date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.update_date).HasColumnType("datetime");

            entity.HasOne(d => d.entry_master).WithMany(p => p.entry_details)
                .HasForeignKey(d => d.entry_master_id)
                .HasConstraintName("FK_entry_detail_entry_master");

            entity.HasOne(d => d.product).WithMany(p => p.entry_details)
                .HasForeignKey(d => d.product_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_entry_detail_product");
        });

        modelBuilder.Entity<entry_master>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK_entry_detail");

            entity.ToTable("entry_master");

            entity.Property(e => e.create_date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.update_date).HasColumnType("datetime");
            entity.Property(e => e.waybill_date).HasColumnType("datetime");
            entity.Property(e => e.waybill_no).HasMaxLength(50);
        });

        modelBuilder.Entity<home>(entity =>
        {
            entity.ToTable("home");

            entity.Property(e => e.create_date).HasColumnType("datetime");
            entity.Property(e => e.name).HasMaxLength(100);
            entity.Property(e => e.slider_image_url).HasMaxLength(200);
            entity.Property(e => e.thumbnail_url).HasMaxLength(200);
            entity.Property(e => e.update_date).HasColumnType("datetime");

            entity.HasOne(d => d.product).WithMany(p => p.homes)
                .HasForeignKey(d => d.product_id)
                .HasConstraintName("FK_home_home");
        });

        modelBuilder.Entity<order>(entity =>
        {
            entity.ToTable("order");

            entity.Property(e => e.address).HasColumnType("text");
            entity.Property(e => e.create_date).HasColumnType("datetime");
            entity.Property(e => e.delivery).HasMaxLength(50);
            entity.Property(e => e.update_date).HasColumnType("datetime");

            entity.HasOne(d => d.basket).WithMany(p => p.orders)
                .HasForeignKey(d => d.basket_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_order_basket");

            entity.HasOne(d => d.product).WithMany(p => p.orders)
                .HasForeignKey(d => d.product_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_order_product");

            entity.HasOne(d => d.user).WithMany(p => p.orders)
                .HasForeignKey(d => d.user_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_order_user");
        });

        modelBuilder.Entity<product>(entity =>
        {
            entity.ToTable("product");

            entity.Property(e => e.code).HasMaxLength(50);
            entity.Property(e => e.create_date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.image_url).HasMaxLength(500);
            entity.Property(e => e.name).HasMaxLength(250);
            entity.Property(e => e.price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.update_date).HasColumnType("datetime");

            entity.HasOne(d => d.category).WithMany(p => p.products)
                .HasForeignKey(d => d.category_id)
                .HasConstraintName("FK_product_category");
        });

        modelBuilder.Entity<stock_movement>(entity =>
        {
            entity.Property(e => e.create_date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.type).HasMaxLength(50);
            entity.Property(e => e.update_date).HasColumnType("datetime");

            entity.HasOne(d => d.order).WithMany(p => p.stock_movements)
                .HasForeignKey(d => d.order_id)
                .HasConstraintName("FK_stock_movements_order");

            entity.HasOne(d => d.product).WithMany(p => p.stock_movements)
                .HasForeignKey(d => d.product_id)
                .HasConstraintName("FK_stock_movements_stock_movements");
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

        modelBuilder.Entity<user_address>(entity =>
        {
            entity.ToTable("user_address");

            entity.Property(e => e.address).HasMaxLength(200);
            entity.Property(e => e.city_id).HasMaxLength(3);
            entity.Property(e => e.create_date).HasColumnType("datetime");
            entity.Property(e => e.district_id).HasMaxLength(10);
            entity.Property(e => e.update_date).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
