namespace Victory.Presentation.Desktop;

public sealed partial class App : System.Windows.Application
{
    public IServiceProvider? ServiceProvider { get; private set; }

    protected override void OnStartup(StartupEventArgs e)
    {
        Dispatcher.UnhandledException += OnDispatcherUnhandledException;

        var serviceCollection = new ServiceCollection();

        ConfigureServices(services: serviceCollection);

        ServiceProvider = serviceCollection.BuildServiceProvider();

        ApplicationConfiguration.ConfigureAPI();

        ApplicationConfiguration.ConfigureSMTP();

        new LoginView().Show();
    }

    private void ConfigureServices(IServiceCollection services)
    {
        // .NET Native DI Abstraction
        services.AddDependencyInjectionConfiguration();

        // Add ViewModels
        services.AddViewModelsConfiguration();

        // MediatR
        services.AddMediatRConfiguration();
    }

    // Global Try Catch

    void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
    {
#if DEBUG
        e.Handled = false;
#else
    ShowUnhandledException(e);    
#endif
    }

    void ShowUnhandledException(DispatcherUnhandledExceptionEventArgs e)
    {
        e.Handled = true;

        string errorMessage = string.Format("A serious error has occurred.\n" +
            "Please check the correctness of the data and repeat the action. If this error happens again, then the" +
            " looks like it's a serious malfunction and you'd better close the application.\n\n" +
            "Error: {0}\n\nDo you want to continue?\n(If you select Yes then you will continue working, if you select No then the application will be closed.)",

        e.Exception.Message + (e.Exception.InnerException != null ? "\n" +
        e.Exception.InnerException.Message : null));

        if (MessageBox.Show(
            messageBoxText: errorMessage,
            caption: "Unexpected error.",
            button: MessageBoxButton.YesNoCancel,
            icon: MessageBoxImage.Error) is MessageBoxResult.No)
        {
            if (MessageBox.Show(
                messageBoxText: "Attention: The application will be closed. All unsaved changes will be lost!\n" +
                "Do you really want to close the app?",
                caption: "Closing the application!",
                button: MessageBoxButton.YesNoCancel,
                icon: MessageBoxImage.Warning) is MessageBoxResult.Yes)
            {
                Current.Shutdown();
            }
        }
    }
}