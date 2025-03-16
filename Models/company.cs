using System;
using System.Collections.Generic;

namespace ecommerce.Models;

public partial class company
{
    public int id { get; set; }

    public int company_id { get; set; }

    public string company_name { get; set; } = null!;

    public string VKN { get; set; } = null!;

    public DateTime create_date { get; set; }

    public DateTime? uptade_date { get; set; }
}
