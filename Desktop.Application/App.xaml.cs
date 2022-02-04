using Desktop.Presentation.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using VictoryRestaurant.Desktop.Presentation.ViewModels;

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

        var startupWindow = new LoginView
        {
            DataContext = ServiceProvider.GetService<LoginViewModel>()
        };

        startupWindow.Show();
    }

    private void ConfigureServices(IServiceCollection services)
    {

    }

    private void ConfigureViewModels(IServiceCollection services)
    {
        services.AddTransient<LoginViewModel>();
    }
}
