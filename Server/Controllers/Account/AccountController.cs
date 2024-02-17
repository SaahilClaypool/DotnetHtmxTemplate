using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace AppTemplate.Controllers;

[AllowAnonymous]
public class AccountController : AppController
{
    public IActionResult Login(string returnUrl)
    {
        return View("Login", (returnUrl, returnUrl ?? "/"));
    }

    [HttpPost]
    public async Task<IActionResult> PostLogin(
        [FromForm] Credentials credentials,
        [FromQuery] string? uri = null
    )
    {
        if (!ModelState.IsValid)
            return View("Login", ("error", uri));

        // do login logic here

        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, credentials.Username),
            new(ClaimTypes.Role, "Administrator"),
        };
        var id = new ClaimsIdentity(
            claims,
            CookieAuthenticationDefaults.AuthenticationScheme
        );

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(id)
        );
        return Redirect(!string.IsNullOrWhiteSpace(uri) ? uri : "/");
    }

    public record Credentials(string Username, string Password);

    [Authorize]
    public async Task<IActionResult> LogOut()
    {
        await HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme
        );
        return Redirect("/");
    }
}
