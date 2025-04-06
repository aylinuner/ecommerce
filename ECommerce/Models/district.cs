using System;
using System.Collections.Generic;

namespace ecommerce.Models;

public partial class district
{
    public int id { get; set; }

    public string name { get; set; } = null!;

    public DateTime create_date { get; set; }

    public DateTime? update_date { get; set; }

    public string city_id { get; set; } = null!;

    public virtual ICollection<user_address> user_address { get; set; } = new List<user_address>();
}
