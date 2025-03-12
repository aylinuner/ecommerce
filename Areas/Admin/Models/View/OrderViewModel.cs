namespace ecommerce.Areas.Admin.Models.View
{
    public class OrderViewModel
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public int order_id { get; set; }
        public decimal total_amount { get; set; }
        public string payment_status { get; set; }
        public string delivery_adress { get; set; }
        public DateTime upload_date { get; set; }
        public DateTime payment_date { get; set; }
        public DateTime create_date { get; set; }
        public DateTime update_date { get; set; }
    }
}
