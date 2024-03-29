var builder = WebApplication.CreateBuilder(args);

// Domain description
builder.SetDomainConfiguration();

// API Configuration
builder.SetAPIConfiguration();

RegisterServices(services: builder.Services);

var app = builder.Build();

Configure(app: app);

void RegisterServices(IServiceCollection services)
{
    // Logging
    services.UseLoggingConfiguration(hostBuilder: builder.Host);

    services.AddControllersWithViews(options =>
    {
        options.CacheProfiles.Add(key: "Caching",
            value: new CacheProfile()
            {
                Duration = 600
            });

        options.CacheProfiles.Add(key: "NoCaching",
            value: new CacheProfile()
            {
                Location = ResponseCacheLocation.None,
                NoStore = true
            });
    });

    // Cache
    services.AddCacheConfiguration();

    // Response compression
    services.AddCompressionConfiguration();

    // .NET Native DI Abstraction
    services.AddDependencyInjectionConfiguration();

    // MediatR
    services.AddMediatRConfiguration();
}

void Configure(IApplicationBuilder app)
{
    // Setting up communication with the API.
    app.UseAPIConfiguration();

    // Allow errors pages
    app.UseErrorPages();

    app.UseHttpsRedirection();

    app.UseResponseCompression();

    app.UseStaticFiles(options: new StaticFileOptions()
    {
        OnPrepareResponse = ctx =>
        {
            ctx.Context.Response.Headers.Add(key: "Cache-Control", value: "public,max-age=600");
        }
    });

    app.UseRouting();
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();