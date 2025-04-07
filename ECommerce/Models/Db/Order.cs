using System;
using System.Collections.Generic;

namespace ecommerce.Models;

public partial class Order
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int BasketId { get; set; }

    public int ProductId { get; set; }

    public string Address { get; set; } = null!;

    public string Delivery { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual Basket Basket { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual ICollection<StockMovement> StockMovement { get; set; } = new List<StockMovement>();
}
