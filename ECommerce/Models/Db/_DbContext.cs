using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Text.RegularExpressions;
using ecommerce.Models.Custom;
using ecommerce.Models;

namespace ecommerce.Models.Db
{
    public class _DbContext : IdentityDbContext<AppUser, AppRole, string, IdentityUserClaim<string>, IdentityUserRole<string>, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public _DbContext(DbContextOptions<_DbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }

        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<AppRole> AppRole { get; set; }
        public DbSet<Bank> Bank { get; set; }
        public DbSet<Basket> Basket { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Color> Color { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<DeliveryType> DeliveryType { get; set; }
        public DbSet<District> District { get; set; }
        public DbSet<EntryMaster> EntryMaster { get; set; }
        public DbSet<EntryDetail> EntryDetail { get; set; }
        public DbSet<Home> Home { get; set; }
        public DbSet<Membership> Membership { get; set; }
        public DbSet<Order> Order { get; set; }
        //public DbSet<Product> Product { get; set; }
        public DbSet<StockMaster> StockMaster{ get; set; }
        public DbSet<StockMovement> StockMovement { get; set; }
        public DbSet<UserAddress> UserAddress { get; set; }
        //public DbSet<AppUserProfile> AppUserProfile { get; set; }
    }
}
