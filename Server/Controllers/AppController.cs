namespace AppTemplate.Controllers;

[Route("{controller=Home}/{action=Index}/{id?}")]
public class AppController() : Controller
{
    protected IActionResult Modal(string partialName, object parameter) =>
        PartialView("_modal", new { Name = partialName, Value = parameter });
    
}
