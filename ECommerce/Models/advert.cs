using System;
using System.Collections.Generic;

namespace ecommerce.Models;

public partial class advert
{
    public int ID { get; set; }

    public string ImageURL { get; set; } = null!;

    public string WebsiteURL { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public int Status { get; set; }
}
