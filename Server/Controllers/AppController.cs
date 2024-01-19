using System.Net;
using HtmlTagHelpers;
using Microsoft.Extensions.DependencyInjection;

namespace AppTemplate.Controllers;

public class AppController() : ControllerBase
{
    public IActionResult Hx(
        H view,
        HttpStatusCode? statusCode = null,
        bool renderAsync = false,
        TagBuilder? overrideLayout = null
    )
    {
        // if (
        //     Request.Headers.Accept.Any(
        //         h => h?.Contains("application/json", StringComparison.OrdinalIgnoreCase) == true
        //     )
        // )
        // {
        //     return Ok(model);
        // }
        if (Request.IsHtmx())
        {
            return view.ToActionResult(statusCode, renderAsync);
        }
        else
        {
            if (overrideLayout != null)
                return overrideLayout(view).ToActionResult();
            return Request
                .HttpContext.RequestServices.GetRequiredService<Views>()
                .Layout(view)
                .ToActionResult();
        }
    }
}
