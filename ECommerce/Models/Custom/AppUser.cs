using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

//using Project.ENTITIES.CoreInterfaces;
using System.Security.Principal;

namespace ecommerce.Models.Custom
{
    public class AppUser : IdentityUser
    {

        // Veritabanınızdaki kullanıcı tablosunun sütunlarıyla uyumlu özellikler ekleyin

        [Required(ErrorMessage = "Zorunlu alan")]
        public string FullName { get; set; } // Örnek bir alan

        public AppUser()
        {
            CreatedDate = DateTime.UtcNow;
        }
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        //public virtual AppUserProfile Profile { get; set; }

    }

    public class AppRole : IdentityRole
    {
        // Veritabanınızdaki rol tablosunun sütunlarıyla uyumlu özellikler ekleyin
        public string Description { get; set; } // Örnek bir alan

        // Burada da ekstra özellikler ekleyebilirsiniz
    }
}
