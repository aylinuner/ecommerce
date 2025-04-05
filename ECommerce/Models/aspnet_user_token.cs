using System;
using System.Collections.Generic;

namespace ecommerce.Models;

public partial class aspnet_user_token
{
    public int UserId { get; set; }

    public string LoginProvider { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Value { get; set; }

    public virtual aspnet_user User { get; set; } = null!;
}
