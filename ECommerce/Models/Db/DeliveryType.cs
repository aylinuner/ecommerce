using System;
using System.Collections.Generic;

namespace ecommerce.Models;

public partial class DeliveryType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime? UpdateTime { get; set; }
}
