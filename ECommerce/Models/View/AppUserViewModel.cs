namespace ecommerce.Models.View
{
    public class AppUserViewModel

    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }


        public List<RoleViewModel> Roles { get; set; }
    }

    public class RoleViewModel
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
