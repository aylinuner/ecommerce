// Areas/Admin/Controllers/HomeController.cs
using Microsoft.AspNetCore.Mvc;

[Area("Admin")]
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
