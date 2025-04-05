using System;
using System.Collections.Generic;

namespace ecommerce.Models;

public partial class aspnet_user_claim
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string? ClaimType { get; set; }

    public string? ClaimValue { get; set; }

    public virtual aspnet_user User { get; set; } = null!;
}
