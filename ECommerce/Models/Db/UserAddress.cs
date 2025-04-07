using System;
using System.Collections.Generic;

namespace ecommerce.Models;

public partial class UserAddress
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string CityId { get; set; } = null!;

    public int DistrictId { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual City City { get; set; } = null!;

    public virtual District District { get; set; } = null!;
}
