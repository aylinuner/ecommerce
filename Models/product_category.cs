using System;
using System.Collections.Generic;

namespace ecommerce.Models;

public partial class product_category
{
    public int id { get; set; }

    public DateTime? update_date { get; set; }

    public DateTime create_date { get; set; }

    public string name { get; set; } = null!;

    public string description { get; set; } = null!;

    public decimal price { get; set; }

    public int stock_quantity { get; set; }

    public int category_id { get; set; }
}
