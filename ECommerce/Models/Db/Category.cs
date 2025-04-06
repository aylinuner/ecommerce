using System;
using System.Collections.Generic;

namespace ecommerce.Models;

public partial class Category
{
    public int id { get; set; }

    public string name { get; set; } = null!;

    public int sort_no { get; set; }

    public DateTime create_date { get; set; }

    public DateTime? update_date { get; set; }

    //public virtual ICollection<entry_detail> entry_detail { get; set; } = new List<entry_detail>();

    //public virtual ICollection<product> product { get; set; } = new List<product>();
}
