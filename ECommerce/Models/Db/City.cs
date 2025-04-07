using System;
using System.Collections.Generic;

namespace ecommerce.Models;

public partial class City
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<UserAddress> UserAddress { get; set; } = new List<UserAddress>();
}
