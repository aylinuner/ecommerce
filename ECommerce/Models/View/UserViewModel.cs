using System.ComponentModel.DataAnnotations;

namespace ecommerce.Models.View
{
    //viewmodel ekranda oluşturduğumuz verilerin backendde göndermek için kullandığımız class çeşidi.
    public class UserViewModel
    {
        [Required(ErrorMessage="Ad zorunludur")]
        public string name { get; set; }

        [Required(ErrorMessage ="Soyad zorunludur")]
        public string surname { get; set; }

        //public DateTime date { get; set; }

        [Required(ErrorMessage = "Telefon kodu zorunludur")]
        public string phone_area { get; set; }

        [Required(ErrorMessage = "Cinsiyet bilgisi zorunludur")]
        public char gender { get; set; }

        [Required(ErrorMessage = "Numara zorunludur")]
        public string phone_number { get; set; }

        [Required(ErrorMessage = "Email zorunludur")]
        public string email { get; set; }

        [Required(ErrorMessage = "Email zorunludur")]
        public string password { get; set; }

        [Required(ErrorMessage = "Parola tekrarı zorunludur")]
        public string password_confirm { get; set; }

        [Required(ErrorMessage = " Doğum tarihi zorunludur")]
        public DateOnly birth_date { get; set; }

        // Kullanıcının tüm siparişlerini çekmek için
        //public virtual ICollection<order> orders { get; set; }







    }
}
