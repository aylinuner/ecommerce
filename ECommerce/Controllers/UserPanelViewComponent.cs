using ecommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.ViewComponents
{
    public class UserPanelViewComponent : ViewComponent
    {
    public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
   
}
