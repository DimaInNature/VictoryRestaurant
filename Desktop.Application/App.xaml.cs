namespace VictoryRestaurant.Desktop.Presentation;

public sealed partial class App : Application
{
    public IServiceProvider? ServiceProvider { get; private set; }

    protected override void OnStartup(StartupEventArgs e)
    {
        var serviceCollection = new ServiceCollection();

        ConfigureServices(services: serviceCollection);

        ServiceProvider = serviceCollection.BuildServiceProvider();

        new LoginView().Show();
    }

    private void ConfigureServices(IServiceCollection services)
    {
        // .NET Native DI Abstraction
        services.AddDependencyInjectionConfiguration();

        // Add ViewModels
        services.AddViewModelsConfiguration();
    }
}