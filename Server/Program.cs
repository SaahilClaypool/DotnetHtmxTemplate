global using Microsoft.AspNetCore.Authorization;
global using AppTemplate;
global using Core;
global using Htmx;
global using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.Configure<RazorViewEngineOptions>(o =>
{
    o.ViewLocationFormats.Add(
        "/Controllers/{1}/{0}" + RazorViewEngine.ViewExtension
    );
    o.ViewLocationFormats.Add(
        "/Controllers/{1}/Views/{0}" + RazorViewEngine.ViewExtension
    );
    o.ViewLocationFormats.Add(
        "/Controllers/Views/{0}" + RazorViewEngine.ViewExtension
    );
    o.ViewLocationFormats.Add(
        "/Controllers/Views/Shared/{0}" + RazorViewEngine.ViewExtension
    );
});

services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(o =>
    {
        o.LoginPath = "/Account/LogIn";
        o.LogoutPath = "/Account/LogOut";
    });
services.RegisterServicesFromAttribute();

services.AddDbContext<AppDb>();
services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.MapGet(
    "/debug/routes",
    (IEnumerable<EndpointDataSource> endpointSources) =>
        string.Join(
            "\n",
            endpointSources.SelectMany(source => source.Endpoints)
        )
);

app.Run();
