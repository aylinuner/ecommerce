// Areas/Admin/Controllers/HomeController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Area("Admin")]

[Authorize(Roles = "Admin")]

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
