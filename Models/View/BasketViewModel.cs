namespace ecommerce.Models.View
{
    public class BasketViewModel
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public int product_id { get; set; }
        public string payment_status { get; set; }
        public string payment_method { get; set; }

     

    }
}
