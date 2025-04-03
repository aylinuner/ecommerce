namespace ecommerce.Models.View
{
    public class UserAddressViewModel
    {
        public int id { get; set; }
        public string name { get; set; }

        public string address  { get; set; }
        public string city_id { get; set; }
        public string district_id { get; set; }
        public DateTime create_date { get; set; }
        public DateTime update_date { get; set; }
        public bool selected { get; set; } // Seçili olup olmadığını belirten özellik
        public city city { get; set; }    // ✅ City tablosuyla ilişki
        public district district{ get; set; }    // ✅ District tablosuyla ilişki



    }
}
