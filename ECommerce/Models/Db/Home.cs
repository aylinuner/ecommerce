using System;
using System.Collections.Generic;

namespace ecommerce.Models;

public partial class Home
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string SliderImageUrl { get; set; } = null!;

    public string ThumbnailUrl { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? ProductId { get; set; }

    public virtual Product? Product { get; set; }
}
