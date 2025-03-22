using System;
using System.Collections.Generic;

namespace ecommerce.Models;

public partial class basket
{
    public int id { get; set; }

    public int count { get; set; }

    public int price { get; set; }

    public DateTime create_date { get; set; }

    public DateTime? update_time { get; set; }
}
