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

    public virtual ICollection<basket> basket { get; set; } = new List<basket>();

    public virtual category category { get; set; } = null!;

    public virtual ICollection<entry_detail> entry_detail { get; set; } = new List<entry_detail>();

    public virtual ICollection<order> order { get; set; } = new List<order>();

    public virtual ICollection<stock_movement> stock_movement { get; set; } = new List<stock_movement>();
}
