global using AppTemplate;
global using Core;
global using Htmx;
global using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;

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
    o.ViewLocationFormats.Add("/Views/{0}" + RazorViewEngine.ViewExtension);
});

services.RegisterServicesFromAttribute();

services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
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
