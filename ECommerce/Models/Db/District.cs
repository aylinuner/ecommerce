using System;
using System.Collections.Generic;

namespace ecommerce.Models;

public partial class District
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public string CityId { get; set; } = null!;

    public virtual ICollection<UserAddress> UserAddress { get; set; } = new List<UserAddress>();
}
