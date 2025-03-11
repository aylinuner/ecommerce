using System;
using System.Collections.Generic;

namespace ecommerce.Models;

public partial class product
{
    public int id { get; set; }

    public string name { get; set; } = null!;

    public string description { get; set; } = null!;

    public decimal price { get; set; }

    public string? image_url { get; set; }

    public int category_id { get; set; }

    public int stock_quantity { get; set; }

    public string? color { get; set; }

    public string? size { get; set; }

    public string? sku { get; set; }

    public decimal? rating { get; set; }

    public DateTime create_date { get; set; }

    public DateTime? update_date { get; set; }
}
