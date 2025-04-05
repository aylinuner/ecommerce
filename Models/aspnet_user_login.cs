using System;
using System.Collections.Generic;

namespace ecommerce.Models;

public partial class aspnet_user_login
{
    public string LoginProvider { get; set; } = null!;

    public string ProviderKey { get; set; } = null!;

    public string? ProviderDisplayName { get; set; }

    public int UserId { get; set; }

    public virtual aspnet_user User { get; set; } = null!;
}
