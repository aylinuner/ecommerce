using System;
using System.Collections.Generic;

namespace ecommerce.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal Price { get; set; }

    public string ImageUrl { get; set; } = null!;

    public int CategoryId { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    //public virtual ICollection<Basket> Basket { get; set; } = new List<Basket>();

    //public virtual Category Category { get; set; } = null!;

    //public virtual ICollection<EntryDetail> EntryDetail { get; set; } = new List<EntryDetail>();

    //public virtual ICollection<Order> Order { get; set; } = new List<Order>();

    //public virtual ICollection<StockMovement> StockMovement { get; set; } = new List<StockMovement>();
}
