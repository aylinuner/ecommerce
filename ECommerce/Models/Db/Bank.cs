using System;
using System.Collections.Generic;

namespace ecommerce.Models;

public partial class Bank
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public DateTime? UpdateTime { get; set; }
}
