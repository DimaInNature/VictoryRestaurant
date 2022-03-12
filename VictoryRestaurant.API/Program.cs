var builder = WebApplication.CreateBuilder(args);

RegisterServices(services: builder.Services);

var app = builder.Build();

Configure(app: app);

// Register All Api's
app.Services.GetServices<IApi>().ToList()
    .ForEach(x => x?.Register(app));

app.Run();

void RegisterServices(IServiceCollection services)
{
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();

    services.AddDbContext<ApplicationContext>(options =>
    {
        options.UseSqlite(builder.Configuration.GetConnectionString("Sqlite"));
    });

    services.AddMemoryCache();
    services.TryAdd(descriptor: ServiceDescriptor.Singleton<IMemoryCache, MemoryCache>());

    services.AddScoped<IFoodRepository, FoodRepository>();
    services.AddTransient<IFoodRepositoryService, FoodRepositoryService>();
    services.AddTransient<ICacheService<FoodEntity>, FoodMemoryCacheService>();
    services.AddTransient<IFoodFacadeService, FoodFacadeService>();

    services.AddScoped<IBookingRepository, BookingRepository>();
    services.AddTransient<IBookingRepositoryService, BookingRepositoryService>();
    services.AddTransient<ICacheService<BookingEntity>, BookingMemoryCacheService>();
    services.AddTransient<IBookingFacadeService, BookingFacadeService>();

    services.AddScoped<IContactMessageRepository, ContactMessageRepository>();
    services.AddTransient<IContactMessageRepositoryService, ContactMessageRepositoryService>();
    services.AddTransient<ICacheService<ContactMessageEntity>, ContactMessageMemoryCacheService>();
    services.AddTransient<IContactMessageFacadeService, ContactMessageFacadeService>();

    services.AddScoped<IMailSubscriberRepository, MailSubscriberRepository>();
    services.AddTransient<IMailSubscriberRepositoryService, MailSubscriberRepositoryService>();
    services.AddTransient<ICacheService<MailSubscriberEntity>, MailSubscriberMemoryCacheService>();
    services.AddTransient<IMailSubscriberFacadeService, MailSubscriberFacadeService>();

    services.AddTransient<IApi, FoodApi>();
    services.AddTransient<IApi, BookingApi>();
    services.AddTransient<IApi, ContactMessageApi>();
    services.AddTransient<IApi, MailSubscriberApi>();
}

void Configure(WebApplication app)
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseStaticFiles();

    app.UseHttpsRedirection();
}