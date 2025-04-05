using Microsoft.AspNetCore.Identity;
using Project.ENTITIES.CoreInterfaces;
using System.Security.Principal;

namespace ecommerce.Models.Custom
{
    public class AppUser : IdentityUser<int>, IEntity
    {

        public AppUser()
        {
            CreatedDate = DateTime.UtcNow;
        }
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
       
    }
}
