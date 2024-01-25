namespace AppTemplate.Controllers;

public class Navbar : ViewComponent
{
    public Task<IViewComponentResult> InvokeAsync()
    {
        return Task.FromResult((IViewComponentResult)View(
            new List<NavItem>()
            {
                new("one", "/home"),
                new("two", "/home"),
                new("three", "/home"),
                new("four", "/home")
            }
        ));
    }
}

public record NavItem(
    string Icon, string Link
);