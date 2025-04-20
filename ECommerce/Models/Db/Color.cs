using System;
using System.Collections.Generic;

namespace ecommerce.Models;

public partial class Color
{

    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public virtual StockMaster StockMaster { get; set; } = null!;

}
