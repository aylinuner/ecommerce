using ecommerce.Models;

namespace ecommerce.Areas.Admin.Models.View
{
    public class EntryViewModel
    {

        public int id { get; set; }

        public string waybill_no { get; set; } = null!;

        public DateTime waybill_date { get; set; }

        public int waybill_total { get; set; }

        public int? supplier_id { get; set; }

        public int? receiver_id { get; set; }

        public DateTime create_date { get; set; }

        public DateTime? update_date { get; set; }

        public virtual ICollection<EntryDetailViewModel> entry_details { get; set; } = new List<EntryDetailViewModel>();


    }
    public class EntryDetailViewModel 
    {
        public int id { get; set; }

        public int category_id { get; set; }

        public string category_name { get; set; } = null!;

        public int product_id { get; set; }

        public string product_name { get; set; } = null!;

        public int quantity { get; set; }

        public int total { get; set; }

        public int total_amount { get; set; }

        public int weight { get; set; }

        public DateTime create_date { get; set; }

        public DateTime? update_date { get; set; }

        public int entry_master_id { get; set; }

    }

}
