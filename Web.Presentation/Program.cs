var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMemoryCache();
builder.Services.TryAdd(descriptor: ServiceDescriptor.Singleton<IMemoryCache, MemoryCache>());

builder.Services.AddSingleton<IFoodRepository, FoodRepository>();
builder.Services.AddTransient<IFoodRepositoryService, FoodRepositoryService>();
builder.Services.AddTransient<FoodRepositoryServiceLoggerDecorator>();
builder.Services.AddTransient<ICacheService<Food>, FoodMemoryCacheService>();
builder.Services.AddTransient<IFoodFacadeService, FoodFacadeService>();

builder.Services.AddSingleton<IBookingRepository, BookingRepository>();
builder.Services.AddTransient<IBookingRepositoryService, BookingRepositoryService>();
builder.Services.AddTransient<BookingRepositoryServiceLoggerDecorator>();
builder.Services.AddTransient<ICacheService<Booking>, BookingMemoryCacheService>();
builder.Services.AddTransient<IBookingFacaceService, BookingFacadeService>();

builder.Services.AddSingleton<IContactMessageRepository, ContactMessageRepository>();
builder.Services.AddTransient<IContactMessageRepositoryService, ContactMessageRepositoryService>();
builder.Services.AddTransient<ContactMessageRepositoryServiceLoggerDecorator>();
builder.Services.AddTransient<ICacheService<ContactMessage>, ContactMessageMemoryCacheService>();
builder.Services.AddTransient<IContactMessageFacadeService, ContactMessageFacadeService>();

builder.Services.AddTransient<IMailSubscriberRepository, MailSubscriberRepository>();
builder.Services.AddTransient<IMailSubscriberRepositoryService, MailSubscriberRepositoryService>();
builder.Services.AddTransient<MailSubscriberRepositoryServiceLoggerDecorator>();
builder.Services.AddTransient<ICacheService<MailSubscriber>, MailSubscriberMemoryCacheService>();
builder.Services.AddTransient<IMailSubscriberFacadeService, MailSubscriberFacadeService>();

builder.Services.AddResponseCompression(options => options.EnableForHttps = true);

builder.Services.Configure<BrotliCompressionProviderOptions>(options =>
{
    options.Level = CompressionLevel.Optimal;
});

builder.Services.AddControllersWithViews(options =>
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

var app = builder.Build();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();