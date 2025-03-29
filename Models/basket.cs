using System;
using System.Collections.Generic;

namespace ecommerce.Models;

public partial class basket
{
    public int id { get; set; }

    public int user_id { get; set; }

    public int basket_id { get; set; }

    public DateTime create_date { get; set; }

    public DateTime? uptade_date { get; set; }

    public int product_id { get; set; }

    public string product_name { get; set; } = null!;

    public int amount { get; set; }

    public int quantity { get; set; }

    public string? image_url { get; set; }

    public int stock_status { get; set; }

    public int shipping_fee { get; set; }

    public int basket_total { get; set; }

    public string payment_status { get; set; } = null!;

    public string payment_method { get; set; } = null!;

    public string shipping_address { get; set; } = null!;
}
