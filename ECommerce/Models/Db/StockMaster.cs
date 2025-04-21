using System;
using System.Collections.Generic;

namespace ecommerce.Models;

public partial class StockMaster
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int ColorId { get; set; }
    public string Storage { get; set; }
    public string Code { get; set; }
    public string ImageUrl { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }

}

