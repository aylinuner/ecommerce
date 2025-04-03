using System;
using System.Collections.Generic;

namespace ecommerce.Models;

public partial class delivery_type
{
    public int id { get; set; }

    public string name { get; set; } = null!;

    public decimal price { get; set; }

    public DateTime create_date { get; set; }

    public DateTime? update_date { get; set; }
}
