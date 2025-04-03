using System;
using System.Collections.Generic;

namespace ecommerce.Models;

public partial class district
{
    public string id { get; set; } = null!;

    public string name { get; set; } = null!;

    public DateTime create_date { get; set; }

    public DateTime? update_date { get; set; }

    public int city_id { get; set; }
}
