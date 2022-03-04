var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IFoodRepository, FoodRepository>();
builder.Services.AddTransient<IFoodRepositoryService, FoodRepositoryService>();
builder.Services.AddTransient<IFoodFacadeService, FoodFacadeService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();