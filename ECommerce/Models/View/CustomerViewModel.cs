using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.ComponentModel.DataAnnotations;

namespace ecommerce.Models.View
{
    public class CustomerViewModel
    {
        public string name { get; set; }
        public string surname { get; set; }
        //public string phone_area { get; set; }
        public string phone_number { get; set; }
        [Required]
        public string gender { get; set; }
        public DateTime create_date { get; set; }
        public DateTime birth_date { get; set; }
        public DateTime save_date { get; set; }

        //public string email { get; set; }
        //public string password { get; set; }
        public string type { get; set; }
      
    }
}

