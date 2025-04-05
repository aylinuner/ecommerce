using System;
using System.Collections.Generic;

namespace ecommerce.Models;

public partial class membership
{
    public int id { get; set; }

    public int user_id { get; set; }

    public DateTime create_date { get; set; }

    public DateTime? update_date { get; set; }

    public virtual user user { get; set; } = null!;
}
