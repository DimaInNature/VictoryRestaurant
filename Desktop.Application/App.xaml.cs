using Desktop.Presentation.ViewModels.UserControls;

namespace VictoryRestaurant.Desktop.Presentation;

public partial class App : Application
{
    public IServiceProvider ServiceProvider { get; private set; }

    protected override void OnStartup(StartupEventArgs e)
    {
        var serviceCollection = new ServiceCollection();

        ConfigureServices(services: serviceCollection);

        ConfigureViewModels(services: serviceCollection);

        ServiceProvider = serviceCollection.BuildServiceProvider();

        new LoginView().Show();
    }

    private void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<IFoodRepository, FoodRepository>();
        services.AddTransient<IFoodRepositoryService, FoodRepositoryService>();
    }

    private void ConfigureViewModels(IServiceCollection services)
    {
        services.AddTransient<LoginViewModel>();
        services.AddTransient<MainViewModel>();
        services.AddTransient<FoodViewModel>();
    }
}
