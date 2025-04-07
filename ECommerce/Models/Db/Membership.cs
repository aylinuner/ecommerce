using System;
using System.Collections.Generic;

namespace ecommerce.Models;

public partial class Membership
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }
}
