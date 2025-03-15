using System;
using System.Collections.Generic;

namespace ecommerce.Models;

public partial class entry_master
{
    public int id { get; set; }

    public int waybill_no { get; set; }

    public DateTime waybill_date { get; set; }

    public int waybill_total { get; set; }

    public string supplier { get; set; } = null!;

    public DateTime create_date { get; set; }

    public DateTime? update_date { get; set; }
}
