namespace AppTemplate;

[Service(ServiceType = ServiceType.Singleton)]
public class Views(IConfiguration config)
{
    public H Layout(H content)
    {
        return html()(
            head()(
                link(("href", "/dist/styles.css"), ("rel", "stylesheet"))(),
                script(src("/dist/bundle.js"))(),
                If(
                    config["ASPNETCORE_ENVIRONMENT"] == "Development",
                    script(src("/_framework/aspnetcore-browser-refresh.js"))(),
                    Empty
                )
            ),
            body()(h2(clss("font-bold p-4"))("Template App"), content)
        );
    }
}
