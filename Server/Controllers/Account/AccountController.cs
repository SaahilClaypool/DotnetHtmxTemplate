using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace AppTemplate.Controllers;

public class AccountController : AppController
{
    public IActionResult Login(string returnUrl)
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> PostLogin(
        [FromForm] Credentials credentials
    )
    {
        if (!ModelState.IsValid)
            return View("Login");

        // do login logic here

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new System.Security.Claims.ClaimsPrincipal()
        );
        return View();
    }

    public record Credentials(string Username, string Password);

    public async Task<IActionResult> LogOut()
    {
        await HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme
        );
        return Redirect("/");
    }
}
