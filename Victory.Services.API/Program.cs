var builder = WebApplication.CreateBuilder(args);

RegisterServices(services: builder.Services);

var app = builder.Build();

Configure(app: app);

app.Run();

void RegisterServices(IServiceCollection services)
{
    // Jwt Auth
    services.AddAuthentication(builder);

    services.AddCors();

    // Setting DBContext
    services.AddDatabaseConfiguration(builder);

    // Cache
    services.AddCacheConfiguration();

    // Swagger
    services.AddSwaggerConfiguration();

    // .NET Native DI Abstraction
    services.AddDependencyInjectionConfiguration();

    // Redis
    services.AddRedisConfiguration(builder);

    // MediatR
    services.AddMediatRConfiguration();

    services.AddControllers();
}

void Configure(WebApplication app)
{
    app.UseHttpsRedirection();

    app.UseCors(cors =>
    {
        cors.AllowAnyHeader();
        cors.AllowAnyMethod();
        cors.AllowAnyOrigin();
    });

    app.UseStaticFiles();

    app.UseAuthentication();

    app.UseAuthorization();

    app.MapControllers();

    app.UseSwaggerSetup();
}