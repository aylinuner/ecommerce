using System;
using System.Collections.Generic;

namespace ecommerce.Models;

public partial class role
{
    public string id { get; set; } = null!;

    public string? name { get; set; }

    public string? normalized_name { get; set; }

    public string? concurrency_stamp { get; set; }

    public virtual ICollection<role_claim> role_claim { get; set; } = new List<role_claim>();

    public virtual ICollection<user> user { get; set; } = new List<user>();
}
