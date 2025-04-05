using System;
using System.Collections.Generic;

namespace ecommerce.Models;

public partial class bank
{
    public int id { get; set; }

    public string name { get; set; } = null!;

    public DateTime create_date { get; set; }

    public DateTime? update_time { get; set; }
}
