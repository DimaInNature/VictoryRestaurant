var builder = WebApplication.CreateBuilder(args);

// Company description
builder.SetCompanyConfiguration();

RegisterServices(services: builder.Services);

var app = builder.Build();

Configure(app: app);

void RegisterServices(IServiceCollection services)
{
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

    // AutoMapper Settings
    services.AddAutoMapperConfiguration();

    // Cache
    services.AddCacheConfiguration();

    // Response compression
    services.AddCompressionConfiguration();

    // Authentication
    services.AddAuthenticationConfiguration();

    // .NET Native DI Abstraction
    services.AddDependencyInjectionConfiguration();
}

void Configure(IApplicationBuilder app)
{
    app.UseHttpsRedirection();

    app.UseResponseCompression();

    app.UseStaticFiles(options: new StaticFileOptions()
    {
        OnPrepareResponse = ctx =>
        {
            ctx.Context.Response.Headers.Add("Cache-Control", "public,max-age=600");
        }
    });

    app.UseRouting();

    app.UseAuthenticationConfiguration();
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();