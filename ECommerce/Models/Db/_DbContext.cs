using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Text.RegularExpressions;
using ecommerce.Models.Custom;

namespace ecommerce.Models.Db
{
    public class _DbContext : IdentityDbContext<AppUser, IdentityRole, string, IdentityUserClaim<string>, IdentityUserRole<string>, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public _DbContext(DbContextOptions<_DbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Product> Product { get; set; }


    }
}
