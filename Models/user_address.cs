using System;
using System.Collections.Generic;

namespace ecommerce.Models;

public partial class user_address
{
    public int id { get; set; }

    public string address { get; set; } = null!;

    public string city_id { get; set; } = null!;

    public string district_id { get; set; } = null!;

    public DateTime create_date { get; set; }

    public DateTime? update_date { get; set; }
}
