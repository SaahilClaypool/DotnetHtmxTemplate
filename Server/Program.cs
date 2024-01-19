global using AppTemplate;
global using Eighty.AspNetCore.Mvc.ActionResults;
global using static HtmlTagHelpers.Prelude;
global using Htmx;
global using Microsoft.AspNetCore.Mvc;
global using H = Eighty.Html;
using Eighty.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.Configure<RazorViewEngineOptions>(o =>
{
    o.ViewLocationFormats.Clear();
    o.ViewLocationFormats.Add(
        "/Controllers/{1}/{0}" + RazorViewEngine.ViewExtension
    );
    o.ViewLocationFormats.Add("/Views/{0}" + RazorViewEngine.ViewExtension);
});

ServiceAttribute.RegisterServices(services);

services.AddControllersWithViews().AddEighty(o => { });

var app = builder.Build();

app.UseStaticFiles();
app.MapDefaultControllerRoute();

app.MapGet(
    "/debug/routes",
    (IEnumerable<EndpointDataSource> endpointSources) =>
        string.Join(
            "\n",
            endpointSources.SelectMany(source => source.Endpoints)
        )
);

app.Run();
