using System;
using System.Collections.Generic;

namespace ecommerce.Models;

public partial class city
{
    public string id { get; set; } = null!;

    public string name { get; set; } = null!;

    public DateTime create_date { get; set; }

    public DateTime? update_date { get; set; }

    public virtual ICollection<user_address> user_address { get; set; } = new List<user_address>();
}
