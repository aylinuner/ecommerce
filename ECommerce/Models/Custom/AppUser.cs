using Microsoft.AspNetCore.Identity;
//using Project.ENTITIES.CoreInterfaces;
using System.Security.Principal;

namespace ecommerce.Models.Custom
{
    public class AppUser : IdentityUser
    {

        // Veritabanınızdaki kullanıcı tablosunun sütunlarıyla uyumlu özellikler ekleyin
        public string FullName { get; set; } // Örnek bir alan

        //public AppUser()
        //{
        //    CreatedDate = DateTime.UtcNow;
        //}
        //public int ID { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public DateTime? ModifiedDate { get; set; }
        //public DateTime? DeletedDate { get; set; }

    }

    public class AppRole : IdentityRole
    {
        // Veritabanınızdaki rol tablosunun sütunlarıyla uyumlu özellikler ekleyin
        public string Description { get; set; } // Örnek bir alan

        // Burada da ekstra özellikler ekleyebilirsiniz
    }
}
