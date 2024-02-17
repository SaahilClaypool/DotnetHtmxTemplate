namespace AppTemplate.Controllers;

public class Navbar : ViewComponent
{
    public Task<IViewComponentResult> InvokeAsync()
    {
        return Task.FromResult((IViewComponentResult)View(
            new List<NavItem>()
            {
                new("one", "/nav/one"),
                new("two", "/nav/two"),
                new("three", "/nav/three"),
            }
        ));
    }
}

public record NavItem(
    string Icon, string Link
);