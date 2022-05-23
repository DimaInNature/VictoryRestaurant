namespace Victory.Presentation.Mobile
{
    public partial class App : Application
    {
        private static IServiceProvider? _serviceProvider;

        public App()
        {
            InitializeComponent();

            Device.SetFlags(flags: new[] { "SwipeView_Experimental" });

            SetupServices(services: new ServiceCollection());

            MainPage = new NavigationPage(root: new MainView());
        }

        public static TViewModel? GetViewModel<TViewModel>() where TViewModel : BaseViewModel =>
            _serviceProvider?.GetService<TViewModel>() ?? throw new NullReferenceException(message: "ViewModel is null");

        public static TService? GetService<TService>()
            where TService : class, IService => _serviceProvider?.GetService<TService>();

        private static void SetupServices(IServiceCollection services)
        {
            ConfigureServices(services);

            _serviceProvider = services.BuildServiceProvider();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            // .NET Native DI Abstraction
            services.AddDependencyInjectionConfiguration();

            // Add ViewModels
            services.AddViewModelsConfiguration();

            // MediatR
            services.AddMediatRConfiguration();
        }
    }
}