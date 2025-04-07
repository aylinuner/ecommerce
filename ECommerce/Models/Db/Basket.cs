using System;
using System.Collections.Generic;

namespace ecommerce.Models;

public partial class Basket
{
    public int Id { get; set; }

    public int UserId { get; set; }

    //public int ProductId { get; set; }

    public int BasketTotal { get; set; }

    public int Subtotal { get; set; }

    public int Quantity { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    //public virtual ICollection<Order> Order { get; set; } = new List<Order>();

    //public virtual Product Product { get; set; } = null!;
}
