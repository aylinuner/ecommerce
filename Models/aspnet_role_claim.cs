using System;
using System.Collections.Generic;

namespace ecommerce.Models;

public partial class aspnet_role_claim
{
    public int Id { get; set; }

    public int RoleId { get; set; }

    public string? ClaimType { get; set; }

    public string? ClaimValue { get; set; }

    public virtual aspnet_role Role { get; set; } = null!;
}
