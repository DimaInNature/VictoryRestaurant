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

    services.AddSingleton<ITokenService, TokenService>();

    builder.Services.AddAuthorization();
    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(
                    key: Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
            };
        });

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

    services.AddScoped<IUserRepository, UserRepository>();
    services.AddTransient<IUserRepositoryService, UserRepositoryService>();
    services.AddTransient<ICacheService<UserEntity>, UserMemoryCacheService>();
    services.AddTransient<IUserFacadeService, UserFacadeService>();

    services.AddTransient<IApi, FoodApi>();
    services.AddTransient<IApi, BookingApi>();
    services.AddTransient<IApi, ContactMessageApi>();
    services.AddTransient<IApi, MailSubscriberApi>();
    services.AddTransient<IApi, UserApi>();
    services.AddSingleton<IApi, AuthorizationApi>();
}

void Configure(WebApplication app)
{
    app.UseAuthentication();
    app.UseAuthorization();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseStaticFiles();

    app.UseHttpsRedirection();
}