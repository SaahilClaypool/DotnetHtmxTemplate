namespace AppTemplate.Controllers;

[Route("{controller=Home}/{action=Index}/{id?}")]
public class AppController() : Controller
{
    protected bool Hx() =>
        Request.IsHtmx() && !Request.IsHtmxHistoryRestoreRequest();

    protected IActionResult Modal(
        string partialName,
        object parameter
    ) =>
        PartialView(
            "_modal",
            new
            {
                Name = partialName,
                Value = parameter
            }
        );

    protected IActionResult Hx(string name, object parameter)
    {
        if (Request.IsHtmx() && !Request.IsHtmxHistoryRestoreRequest())
            return PartialView(name, parameter);
        return View(name, parameter);
    }
}
