using System;
using System.Collections.Generic;

namespace ecommerce.Models;

public partial class EntryDetail
{
    public int id { get; set; }

    public int category_id { get; set; }

    public int product_id { get; set; }

    public int quantity { get; set; }

    public int amount { get; set; }

    public int total_amount { get; set; }

    public int weight { get; set; }

    public DateTime create_date { get; set; }

    public DateTime? update_date { get; set; }

    public int entry_master_id { get; set; }

    //public virtual category category { get; set; } = null!;

    //public virtual entry_master entry_master { get; set; } = null!;

    //public virtual product product { get; set; } = null!;
}
