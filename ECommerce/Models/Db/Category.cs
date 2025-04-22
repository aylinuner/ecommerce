using System;
using System.Collections.Generic;

namespace ecommerce.Models;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int SortNo { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    //public virtual ICollection<EntryDetail> EntryDetail { get; set; } = new List<EntryDetail>();

    //public virtual ICollection<Product> Product { get; set; } = new List<Product>();
}
