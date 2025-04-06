using System;
using System.Collections.Generic;

namespace ecommerce.Models;

public partial class user_login
{
    public string login_provider { get; set; } = null!;

    public string provider_key { get; set; } = null!;

    public string? provider_display_name { get; set; }

    public string user_id { get; set; } = null!;

    public virtual user user { get; set; } = null!;
}
