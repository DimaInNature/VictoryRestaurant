namespace Victory.Presentation.Mobile.Core.Configuration;

internal static class DependencyInjectionConfiguration
{
    public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
    {
        if (services is null) throw new ArgumentNullException(nameof(services));

        services.AddScoped<IFoodRepositoryService, FoodRepositoryService>();

        services.AddTransient<IBookingRepositoryService, BookingRepositoryService>();
    }

    public static void AddViewModelsConfiguration(this IServiceCollection services)
    {
        if (services is null) throw new ArgumentNullException(nameof(services));

        services.AddTransient<BookingViewModel>();
        services.AddTransient<MenuViewModel>();
        services.AddTransient<MainViewModel>();
    }
}