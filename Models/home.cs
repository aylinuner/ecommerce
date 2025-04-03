using System;
using System.Collections.Generic;

namespace ecommerce.Models;

public partial class home
{
    public int id { get; set; }

    public string? name { get; set; }

    public string slider_image_url { get; set; } = null!;

    public string thumbnail_url { get; set; } = null!;

    public DateTime create_date { get; set; }

    public DateTime? update_date { get; set; }

    public int? product_id { get; set; }

    public virtual product? product { get; set; }
}
