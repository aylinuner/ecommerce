using System;
using System.Collections.Generic;

namespace ecommerce.Models;

public partial class aspnet_user
{
    public int Id { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public int Status { get; set; }

    public string? UserName { get; set; }

    public string? NormalizedUserName { get; set; }

    public string? Email { get; set; }

    public string? NormalizedEmail { get; set; }

    public bool EmailConfirmed { get; set; }

    public string? PasswordHash { get; set; }

    public string? SecurityStamp { get; set; }

    public string? ConcurrencyStamp { get; set; }

    public string? PhoneNumber { get; set; }

    public bool PhoneNumberConfirmed { get; set; }

    public bool TwoFactorEnabled { get; set; }

    public DateTimeOffset? LockoutEnd { get; set; }

    public bool LockoutEnabled { get; set; }

    public int AccessFailedCount { get; set; }

    public virtual ICollection<aspnet_user_claim> aspnet_user_claims { get; set; } = new List<aspnet_user_claim>();

    public virtual ICollection<aspnet_user_login> aspnet_user_logins { get; set; } = new List<aspnet_user_login>();

    public virtual ICollection<aspnet_user_token> aspnet_user_tokens { get; set; } = new List<aspnet_user_token>();

    public virtual profile? profile { get; set; }

    public virtual ICollection<aspnet_role> Roles { get; set; } = new List<aspnet_role>();
}
