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
                // htmx plugins
                script(
                    (
                        "src",
                        "https://unpkg.com/idiomorph/dist/idiomorph-ext.min.js"
                    )
                )(),
                If(
                    config["ASPNETCORE_ENVIRONMENT"] == "Development",
                    script(src("/_framework/aspnetcore-browser-refresh.js"))(),
                    Empty
                )
            ),
            body(("hx-ext", "morph"), ("hx-swap", "morph"))(
                h2(clss("font-bold p-4"))("Template App"),
                content
            )
        );
    }
}
