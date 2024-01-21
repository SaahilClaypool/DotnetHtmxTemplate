namespace AppTemplate.Controllers;

public class HomeController : AppController
{
    public IActionResult Index() {
        return View();
    }

    public IActionResult Counter([FromQuery] int count)
    {
        return PartialView("_counter", count + 1);
    }
}