using System;
using System.Collections.Generic;

namespace ecommerce.Models;

public partial class aspnet_role
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? NormalizedName { get; set; }

    public string? ConcurrencyStamp { get; set; }

    public virtual ICollection<aspnet_role_claim> aspnet_role_claims { get; set; } = new List<aspnet_role_claim>();

    public virtual ICollection<aspnet_user> Users { get; set; } = new List<aspnet_user>();
}
