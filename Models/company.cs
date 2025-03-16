using System;
using System.Collections.Generic;

namespace ecommerce.Models;

public partial class company
{
    public int id { get; set; }

    public string name { get; set; } = null!;

    public string vkn { get; set; } = null!;

    public DateTime create_date { get; set; }

    public DateTime? uptade_date { get; set; }
}
