using System;
using System.Collections.Generic;

namespace ecommerce.Models;

public partial class profile
{
    public int ID { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public int Status { get; set; }

    public virtual aspnet_user IDNavigation { get; set; } = null!;
}
