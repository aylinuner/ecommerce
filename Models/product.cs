using System;
using System.Collections.Generic;

namespace ecommerce.Models;

public partial class product
{
    public int id { get; set; }

    public string name { get; set; } = null!;

    public string code { get; set; } = null!;

    public string description { get; set; } = null!;

    public decimal price { get; set; }

    public string image_url { get; set; } = null!;

    public int category_id { get; set; }

    public DateTime create_date { get; set; }

    public DateTime? update_date { get; set; }

    public virtual category category { get; set; } = null!;
}
