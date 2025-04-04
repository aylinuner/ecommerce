using System;
using System.Collections.Generic;

namespace ecommerce.Models;

public partial class user
{
    public int id { get; set; }

    public DateTime create_time { get; set; }

    public string name { get; set; } = null!;

    public string surname { get; set; } = null!;

    public string gender { get; set; } = null!;

    public string? tckn { get; set; }

    public string? vkn { get; set; }

    public string phone_area { get; set; } = null!;

    public string phone_number { get; set; } = null!;

    public DateTime? update_date { get; set; }

    public string email { get; set; } = null!;

    public string password { get; set; } = null!;

    public DateTime birth_date { get; set; }

    public virtual ICollection<basket> baskets { get; set; } = new List<basket>();

    public virtual ICollection<customer> customers { get; set; } = new List<customer>();

    public virtual ICollection<membership> memberships { get; set; } = new List<membership>();

    public virtual ICollection<order> orders { get; set; } = new List<order>();
}
