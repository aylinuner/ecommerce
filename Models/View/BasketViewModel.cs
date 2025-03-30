namespace ecommerce.Models.View
{
    public class BasketViewModel
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public int product_id { get; set; }
        public int basket_total { get; set; }
        public int subtotal { get; set; }
        public int quantity { get; set; }
        public DateTime create_date { get; set; }
        public DateTime update_date { get; set; }
        public virtual user user { get; set; } = null!; // User tablosuna erişim sağlar
        public virtual product product { get; set; } = null!; // Product tablosuna erişim sağlar





    }
}
