namespace ecommerce.Models.View
{
    public class UserAddressViewModel
    {
        public int id { get; set; }
        public string address  { get; set; }
        public string city_id { get; set; }
        public string district_id { get; set; }
        public DateTime create_date { get; set; }
        public DateTime update_date { get; set; }
    }
}
