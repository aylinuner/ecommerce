using System.Collections.Specialized;

namespace ecommerce.Models
{
    //email gönderirken kullanılacak bilgileri bu clasın içersinde topladım(Hybrid ntierdan örnek aldım)
    public class EmailSetting
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public string DisplayName { get; set; }
        public int Port { get; set; }

    }
}
