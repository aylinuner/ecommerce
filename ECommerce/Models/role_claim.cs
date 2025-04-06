using System;
using System.Collections.Generic;

namespace ecommerce.Models;

public partial class role_claim
{
    public int id { get; set; }

    public string role_id { get; set; } = null!;

    public string? claim_type { get; set; }

    public string? claim_value { get; set; }

    public virtual role role { get; set; } = null!;
}
