using ecommerce.Models;

namespace ecommerce.Models.View
{
    public class OrderViewModel
    {
        public int id { get; set; }

        public int user_id { get; set; }
        public int basket_id { get; set; }
        public int product_id { get; set; }

        public string delivery { get; set; }
        public string address { get; set; }
        public DateTime create_date { get; set; }
        public DateTime update_date { get; set; }
        public virtual user user { get; set; } = null!; // User tablosuna erişim sağlar
        public virtual product product { get; set; } = null!; // Product tablosuna erişim sağlar
        public virtual basket basket { get; set; } = null!; // Basket tablosuna erişim sağlar



    }
}
