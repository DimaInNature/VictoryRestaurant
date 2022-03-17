using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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

    services.AddSingleton<IUserRepository, UserRepository>();
    services.AddTransient<IUserRepositoryService, UserRepositoryService>();
    services.AddTransient<UserRepositoryServiceLoggerDecorator>();
    services.AddTransient<ICacheService<User>, UserMemoryCacheService>();
    services.AddTransient<IUserFacadeService, UserFacadeService>();

    services.AddSingleton<IAuthorizationService, AuthorizationService>();

    services.AddResponseCompression(options => options.EnableForHttps = true);

    services.Configure<BrotliCompressionProviderOptions>(options =>
    {
        options.Level = CompressionLevel.Optimal;
    });

    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                   .AddJwtBearer(options =>
                   {
                       options.RequireHttpsMetadata = false;
                       options.TokenValidationParameters = new TokenValidationParameters
                       {
                           // укзывает, будет ли валидироваться издатель при валидации токена
                           ValidateIssuer = true,
                           // строка, представляющая издателя
                           ValidIssuer = "Victory",

                           // будет ли валидироваться потребитель токена
                           ValidateAudience = true,
                           // установка потребителя токена
                           ValidAudience = "Victory",
                           // будет ли валидироваться время существования
                           ValidateLifetime = true,

                           // установка ключа безопасности
                           IssuerSigningKey = new SymmetricSecurityKey(key: Encoding.ASCII.GetBytes("VictoryKey-11111111111111111111111111")),
                           // валидация ключа безопасности
                           ValidateIssuerSigningKey = true,
                       };
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

    app.UseAuthentication();
    app.UseAuthorization();

}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();