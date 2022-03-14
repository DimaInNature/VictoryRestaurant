var builder = WebApplication.CreateBuilder(args);

RegisterServices(services: builder.Services);

var app = builder.Build();

Configure(app: app);

void RegisterServices(IServiceCollection services)
{
    services.AddMemoryCache();
    services.TryAdd(descriptor: ServiceDescriptor.Singleton<IMemoryCache, MemoryCache>());

    services.AddSingleton<IFoodRepository, FoodRepository>();
    services.AddTransient<IFoodRepositoryService, FoodRepositoryService>();
    services.AddTransient<FoodRepositoryServiceLoggerDecorator>();
    services.AddTransient<ICacheService<Food>, FoodMemoryCacheService>();
    services.AddTransient<IFoodFacadeService, FoodFacadeService>();

    services.AddSingleton<IBookingRepository, BookingRepository>();
    services.AddTransient<IBookingRepositoryService, BookingRepositoryService>();
    services.AddTransient<BookingRepositoryServiceLoggerDecorator>();
    services.AddTransient<ICacheService<Booking>, BookingMemoryCacheService>();
    services.AddTransient<IBookingFacaceService, BookingFacadeService>();

    services.AddSingleton<IContactMessageRepository, ContactMessageRepository>();
    services.AddTransient<IContactMessageRepositoryService, ContactMessageRepositoryService>();
    services.AddTransient<ContactMessageRepositoryServiceLoggerDecorator>();
    services.AddTransient<ICacheService<ContactMessage>, ContactMessageMemoryCacheService>();
    services.AddTransient<IContactMessageFacadeService, ContactMessageFacadeService>();

    services.AddTransient<IMailSubscriberRepository, MailSubscriberRepository>();
    services.AddTransient<IMailSubscriberRepositoryService, MailSubscriberRepositoryService>();
    services.AddTransient<MailSubscriberRepositoryServiceLoggerDecorator>();
    services.AddTransient<ICacheService<MailSubscriber>, MailSubscriberMemoryCacheService>();
    services.AddTransient<IMailSubscriberFacadeService, MailSubscriberFacadeService>();

    services.AddSingleton<IAuthorizationService, AuthorizationService>();

    services.AddResponseCompression(options => options.EnableForHttps = true);

    services.Configure<BrotliCompressionProviderOptions>(options =>
    {
        options.Level = CompressionLevel.Optimal;
    });

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

    app.UseAuthorization();
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();