namespace ecommerce.Areas.Admin.Models.View
{
    public class ProductViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string  description { get; set; }
        public decimal price { get; set; }
        public int create_date { get; set; }
    }
}
