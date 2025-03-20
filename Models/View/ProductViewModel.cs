namespace ecommerce.Models.View
{
    public class ProductViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public int price { get; set; }
        public string image_url { get; set; }
        public int category_id { get; set; }
        public DateTime create_date { get; set; }
        public DateTime update_date { get; set; }




    }
}
