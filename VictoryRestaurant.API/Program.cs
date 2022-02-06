using API.Services.Abstract.Repositories;
using API.Services.Repositories;

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

    services.AddScoped<IFoodRepository, FoodRepository>();
    services.AddTransient<IFoodRepositoryService, FoodRepositoryService>();

    services.AddTransient<IApi, FoodApi>();
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