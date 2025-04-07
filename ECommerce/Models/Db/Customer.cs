using System;
using System.Collections.Generic;

namespace ecommerce.Models;

public partial class Customer
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Type { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    public string Gender { get; set; } = null!;

    public string? Tckn { get; set; }

    public string? Vkn { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public DateTime? UpdateDate { get; set; }  

    public DateTime CreateDate { get; set; }

    public DateTime SaveDate { get; set; }
}
