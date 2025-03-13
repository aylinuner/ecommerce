using System;
using System.Collections.Generic;

namespace ecommerce.Models;

public partial class customer
{
    public int id { get; set; }

    public int user_id { get; set; }

    public string type { get; set; } = null!;

    public string name { get; set; } = null!;

    public string surname { get; set; } = null!;

    public string email { get; set; } = null!;

    public string password { get; set; } = null!;

    public DateTime birth_date { get; set; }

    public string gender { get; set; } = null!;

    public string? tckn { get; set; }

    public string? vkn { get; set; }

    public string phone_area { get; set; } = null!;

    public string phone_number { get; set; } = null!;

    public DateTime? update__date { get; set; }

    public DateTime create_date { get; set; }

    public DateTime save_date { get; set; }

    public virtual user user { get; set; } = null!;
}
