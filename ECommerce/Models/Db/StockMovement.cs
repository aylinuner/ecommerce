using System;
using System.Collections.Generic;

namespace ecommerce.Models;

public partial class StockMovement
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public string? Type { get; set; }

    public int? OrderId { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Product Product { get; set; } = null!;
}
