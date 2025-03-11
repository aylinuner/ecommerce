using System;
using System.Collections.Generic;

namespace ecommerce.Models;

public partial class category
{
    public int id { get; set; }

    public string name { get; set; } = null!;

    public int sort_no { get; set; }

    public DateTime create_date { get; set; }

    public DateTime? update_date { get; set; }
}
