//using System;
//using System.Collections.Generic;

//namespace ecommerce.Models;

//public partial class user
//{
//    public string id { get; set; } = null!;

//    public string? user_name { get; set; }

//    public string? normalized_user_name { get; set; }

//    public string? email { get; set; }

//    public string? normalized_email { get; set; }

//    public bool email_confirmed { get; set; }

//    public string? password_hash { get; set; }

//    public string? security_stamp { get; set; }

//    public string? concurrency_stamp { get; set; }

//    public string? phone_number { get; set; }

//    public bool phone_number_confirmed { get; set; }

//    public bool two_factor_enabled { get; set; }

//    public DateTimeOffset? lockout_end { get; set; }

//    public bool lockout_enabled { get; set; }

//    public int access_failed_count { get; set; }

//    public virtual ICollection<user_claim> user_claim { get; set; } = new List<user_claim>();

//    public virtual ICollection<user_login> user_login { get; set; } = new List<user_login>();

//    public virtual ICollection<user_token> user_token { get; set; } = new List<user_token>();

//    public virtual ICollection<role> role { get; set; } = new List<role>();
//}
