namespace AppTemplate.Controllers;

public class NavController : AppController
{
    [ResponseCache(VaryByHeader = "User-Agent", Duration = 0)]
    public ActionResult One() => View("nav", "one");

    public ActionResult Two() => View("nav", "two");

    public ActionResult Three() => View("nav", "three");

    public ActionResult Nested([FromQuery] string id) => View("nested", id);
}
