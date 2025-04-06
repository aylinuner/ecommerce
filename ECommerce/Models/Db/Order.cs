using System;
using System.Collections.Generic;

namespace ecommerce.Models;

public partial class Order
{
    public int id { get; set; }

    public int user_id { get; set; }

    public int basket_id { get; set; }

    public int product_id { get; set; }

    public string address { get; set; } = null!;

    public string delivery { get; set; } = null!;

    public DateTime create_date { get; set; }

    public DateTime? update_date { get; set; }

    //public virtual basket basket { get; set; } = null!;

    //public virtual product product { get; set; } = null!;

    //public virtual ICollection<stock_movement> stock_movement { get; set; } = new List<stock_movement>();
}
