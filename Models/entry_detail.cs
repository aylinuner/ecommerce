using System;
using System.Collections.Generic;

namespace ecommerce.Models;

public partial class entry_detail
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
}
