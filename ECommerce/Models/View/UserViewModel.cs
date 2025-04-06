using System.ComponentModel.DataAnnotations;

namespace ecommerce.Models.View
{
    //viewmodel ekranda oluşturduğumuz verilerin backendde göndermek için kullandığımız class çeşidi.
    public class UserViewModel
    {
        public string name { get; set; }

        public string surname { get; set; }

        //public DateTime date { get; set; }

        public string phone_area { get; set; }

        public string gender { get; set; }


        public string phone_number { get; set; }
        [Required]
        public string email { get; set; }

        public string password { get; set; }

        public string password_confirm { get; set; }

        public DateTime birth_date { get; set; }

        // Kullanıcının tüm siparişlerini çekmek için
        //public virtual ICollection<order> orders { get; set; }







    }
}
