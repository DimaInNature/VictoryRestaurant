var builder = WebApplication.CreateBuilder(args);

RegisterServices(services: builder.Services);

var app = builder.Build();

// Register All Api's
app.Services.GetServices<IApi>().ToList()
    .ForEach(x => x?.Register(app));

Configure(app: app);

app.Run();

void RegisterServices(IServiceCollection services)
{
    services.AddCors();

    // Minimal API
    services.AddEndpointsApiExplorer();

    // Setting DBContext
    services.AddDatabaseConfiguration(builder);

    // Cache
    services.AddCacheConfiguration();

    // Swagger
    services.AddSwaggerConfiguration();

    // .NET Native DI Abstraction
    services.AddDependencyInjectionConfiguration();

    // API
    services.AddAPIConfiguration();

    // MediatR
    services.AddMediatRConfiguration();
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

    app.UseSwaggerSetup();
}