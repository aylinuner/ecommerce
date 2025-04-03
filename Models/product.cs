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

    public virtual ICollection<basket> baskets { get; set; } = new List<basket>();

    public virtual category category { get; set; } = null!;

    public virtual ICollection<entry_detail> entry_details { get; set; } = new List<entry_detail>();

    public virtual ICollection<home> homes { get; set; } = new List<home>();

    public virtual ICollection<order> orders { get; set; } = new List<order>();

    public virtual ICollection<stock_movement> stock_movements { get; set; } = new List<stock_movement>();
}
