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

    public virtual DbSet<__ef_migrations_history> __ef_migrations_histories { get; set; }

    public virtual DbSet<advert> adverts { get; set; }

    public virtual DbSet<aspnet_role> aspnet_roles { get; set; }

    public virtual DbSet<aspnet_role_claim> aspnet_role_claims { get; set; }

    public virtual DbSet<aspnet_user> aspnet_users { get; set; }

    public virtual DbSet<aspnet_user_claim> aspnet_user_claims { get; set; }

    public virtual DbSet<aspnet_user_login> aspnet_user_logins { get; set; }

    public virtual DbSet<aspnet_user_token> aspnet_user_tokens { get; set; }

    public virtual DbSet<bank> banks { get; set; }

    public virtual DbSet<basket> baskets { get; set; }

    public virtual DbSet<brand> brands { get; set; }

    public virtual DbSet<category> categories { get; set; }

    public virtual DbSet<city> cities { get; set; }

    public virtual DbSet<company> companies { get; set; }

    public virtual DbSet<customer> customers { get; set; }

    public virtual DbSet<delivery_type> delivery_types { get; set; }

    public virtual DbSet<district> districts { get; set; }

    public virtual DbSet<entry_detail> entry_details { get; set; }

    public virtual DbSet<entry_master> entry_masters { get; set; }

    public virtual DbSet<home> homes { get; set; }

    public virtual DbSet<membership> memberships { get; set; }

    public virtual DbSet<order> orders { get; set; }

    public virtual DbSet<product> products { get; set; }

    public virtual DbSet<profile> profiles { get; set; }

    public virtual DbSet<stock_movement> stock_movements { get; set; }

    public virtual DbSet<user> users { get; set; }

    public virtual DbSet<user_address> user_addresses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=94.73.170.33;Database=u2211892_etic;User Id=u2211892_etic;Password=0S:-nK98Ue=O6ws.;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<__ef_migrations_history>(entity =>
        {
            entity.HasKey(e => e.MigrationId).HasName("PK___EFMigrationsHistory");

            entity.ToTable("__ef_migrations_history");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
        });

        modelBuilder.Entity<advert>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK_Adverts");
        });

        modelBuilder.Entity<aspnet_role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_AspNetRoles");

            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<aspnet_role_claim>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_AspNetRoleClaims");

            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.aspnet_role_claims)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_AspNetRoleClaims_AspNetRoles_RoleId");
        });

        modelBuilder.Entity<aspnet_user>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_AspNetUsers");

            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "aspnet_user_role",
                    r => r.HasOne<aspnet_role>().WithMany()
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_AspNetUserRoles_AspNetRoles_RoleId"),
                    l => l.HasOne<aspnet_user>().WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_AspNetUserRoles_AspNetUsers_UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId").HasName("PK_AspNetUserRoles");
                        j.ToTable("aspnet_user_roles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<aspnet_user_claim>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_AspNetUserClaims");

            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.aspnet_user_claims)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_AspNetUserClaims_AspNetUsers_UserId");
        });

        modelBuilder.Entity<aspnet_user_login>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey }).HasName("PK_AspNetUserLogins");

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.aspnet_user_logins)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_AspNetUserLogins_AspNetUsers_UserId");
        });

        modelBuilder.Entity<aspnet_user_token>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name }).HasName("PK_AspNetUserTokens");

            entity.HasOne(d => d.User).WithMany(p => p.aspnet_user_tokens)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_AspNetUserTokens_AspNetUsers_UserId");
        });

        modelBuilder.Entity<bank>(entity =>
        {
            entity.ToTable("bank");

            entity.Property(e => e.create_date).HasColumnType("datetime");
            entity.Property(e => e.name).HasMaxLength(50);
            entity.Property(e => e.update_time).HasColumnType("datetime");
        });

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

            entity.Property(e => e.create_date).HasColumnType("datetime");
            entity.Property(e => e.name).HasMaxLength(50);
            entity.Property(e => e.update_time).HasColumnType("datetime");
        });

        modelBuilder.Entity<category>(entity =>
        {
            entity.ToTable("category");

            entity.Property(e => e.id).ValueGeneratedNever();
            entity.Property(e => e.create_date).HasColumnType("datetime");
            entity.Property(e => e.name).HasMaxLength(50);
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
            entity.Property(e => e.name).HasMaxLength(50);
            entity.Property(e => e.update_date).HasColumnType("datetime");
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
        });

        modelBuilder.Entity<delivery_type>(entity =>
        {
            entity.ToTable("delivery_type");

            entity.Property(e => e.id).ValueGeneratedNever();
            entity.Property(e => e.create_date).HasColumnType("datetime");
            entity.Property(e => e.name).HasMaxLength(50);
            entity.Property(e => e.price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.update_time).HasColumnType("datetime");
        });

        modelBuilder.Entity<district>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK_ditrict");

            entity.ToTable("district");

            entity.Property(e => e.city_id).HasMaxLength(3);
            entity.Property(e => e.create_date).HasColumnType("datetime");
            entity.Property(e => e.name).HasMaxLength(100);
            entity.Property(e => e.update_date).HasColumnType("datetime");
        });

        modelBuilder.Entity<entry_detail>(entity =>
        {
            entity.ToTable("entry_detail");

            entity.Property(e => e.create_date).HasColumnType("datetime");
            entity.Property(e => e.update_date).HasColumnType("datetime");

            entity.HasOne(d => d.category).WithMany(p => p.entry_details)
                .HasForeignKey(d => d.category_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_entry_detail_category");

            entity.HasOne(d => d.entry_master).WithMany(p => p.entry_details)
                .HasForeignKey(d => d.entry_master_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_entry_detail_entry_master");

            entity.HasOne(d => d.product).WithMany(p => p.entry_details)
                .HasForeignKey(d => d.product_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_entry_detail_product");
        });

        modelBuilder.Entity<entry_master>(entity =>
        {
            entity.ToTable("entry_master");

            entity.Property(e => e.create_date).HasColumnType("datetime");
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
                .HasConstraintName("FK_home_product");
        });

        modelBuilder.Entity<membership>(entity =>
        {
            entity.ToTable("membership");

            entity.Property(e => e.create_date).HasColumnType("datetime");
            entity.Property(e => e.update_date).HasColumnType("datetime");

            entity.HasOne(d => d.user).WithMany(p => p.memberships)
                .HasForeignKey(d => d.user_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_membership_user");
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
            entity.Property(e => e.create_date).HasColumnType("datetime");
            entity.Property(e => e.image_url).HasMaxLength(500);
            entity.Property(e => e.name).HasMaxLength(250);
            entity.Property(e => e.price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.update_date).HasColumnType("datetime");

            entity.HasOne(d => d.category).WithMany(p => p.products)
                .HasForeignKey(d => d.category_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_product_category");
        });

        modelBuilder.Entity<profile>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK_Profiles");

            entity.Property(e => e.ID).ValueGeneratedNever();

            entity.HasOne(d => d.IDNavigation).WithOne(p => p.profile)
                .HasForeignKey<profile>(d => d.ID)
                .HasConstraintName("FK_Profiles_AspNetUsers_ID");
        });

        modelBuilder.Entity<stock_movement>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK_stock_movements");

            entity.ToTable("stock_movement");

            entity.Property(e => e.create_date).HasColumnType("datetime");
            entity.Property(e => e.type).HasMaxLength(50);
            entity.Property(e => e.update_date).HasColumnType("datetime");

            entity.HasOne(d => d.order).WithMany(p => p.stock_movements)
                .HasForeignKey(d => d.order_id)
                .HasConstraintName("FK_stock_movement_order");

            entity.HasOne(d => d.product).WithMany(p => p.stock_movements)
                .HasForeignKey(d => d.product_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_stock_movement_product");
        });

        modelBuilder.Entity<user>(entity =>
        {
            entity.ToTable("user");

            entity.Property(e => e.birth_date).HasColumnType("datetime");
            entity.Property(e => e.create_date).HasColumnType("datetime");
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
            entity.Property(e => e.name).HasMaxLength(50);
            entity.Property(e => e.update_date).HasColumnType("datetime");

            entity.HasOne(d => d.city).WithMany(p => p.user_addresses)
                .HasForeignKey(d => d.city_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_address_city");

            entity.HasOne(d => d.district).WithMany(p => p.user_addresses)
                .HasForeignKey(d => d.district_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_address_district");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
