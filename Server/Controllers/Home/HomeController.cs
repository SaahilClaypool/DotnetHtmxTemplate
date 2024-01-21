using Microsoft.AspNetCore.Authorization;

namespace AppTemplate.Controllers;

public class HomeController : AppController
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Counter([FromQuery] int count)
    {
        return PartialView("_counter", count + 1);
    }

    [Authorize]
    public IActionResult Authorized()
    {
        return Content("authorized");
    }
}
