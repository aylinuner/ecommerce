namespace ecommerce.Areas.Admin.Models.View
{
    public class EntryViewModel
    {
        public int id { get; set; }
        public int waybill_no { get; set; }
        public DateTime waybill_date { get; set; }
        public int waybill_total { get; set; }
        public string supplier { get; set; }
        public DateTime create_date { get; set; }
        public DateTime update_date { get; set; }
        public string category_name { get; set; }
    }
}
