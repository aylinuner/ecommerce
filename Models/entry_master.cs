using System;
using System.Collections.Generic;

namespace ecommerce.Models;

public partial class entry_master
{
    public int id { get; set; }

    public string waybill_no { get; set; } = null!;

    public DateTime waybill_date { get; set; }

    public int waybill_total { get; set; }

    public int? supplier_id { get; set; }

    public int? receiver_id { get; set; }

    public DateTime create_date { get; set; }

    public DateTime? update_date { get; set; }

    public virtual ICollection<entry_detail> entry_details { get; set; } = new List<entry_detail>();
}
