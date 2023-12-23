namespace AppTemplate.Controllers;

public class HomeController() : AppController
{
    public IActionResult Index()
    {
        return Hx(div()(CounterHtml(0)));
    }

    [HttpGet("/counter")]
    public IActionResult Counter(int cnt) => Hx(CounterHtml(cnt + 1));

    H CounterHtml(int cnt)
    {
        return button(
            clss("btn btn-outline"),
            ("hx-get", "/counter"),
            ("hx-swap", "outerHTML"),
            ("hx-trigger", "click"),
            ("hx-vals", $$"""
            {"cnt": {{cnt}}}
            """)
        )($"value is: {cnt}");
    }
}
