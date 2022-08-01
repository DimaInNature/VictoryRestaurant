var builder = WebApplication.CreateBuilder(args);

// API Configuration
builder.SetAPIConfiguration();

// Mail API Configuration
builder.SetMailConfiguration();

RegisterServices(services: builder.Services);

var app = builder.Build();

Configure(app: app);

app.Run();

void RegisterServices(IServiceCollection services)
{
    services.AddCors();

    services.AddDatabaseConfiguration(configuration: builder.Configuration);

    // Swagger
    services.AddSwaggerConfiguration();

    // .NET Native DI Abstraction
    services.RegisterServices();

    // MediatR
    services.AddMediatRConfiguration();

    services.AddControllers();
}

void Configure(WebApplication app)
{
    app.UseDeveloperExceptionPage();

    app.ConfigureAPI();

    app.ConfigureMailAPI();

    app.UseHttpsRedirection();

    app.UseCors(cors =>
    {
        cors.AllowAnyHeader();
        cors.AllowAnyMethod();
        cors.AllowAnyOrigin();
    });

    app.UseStaticFiles();

    app.MapControllers();

    app.UseSwaggerSetup();
}