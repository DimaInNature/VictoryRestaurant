namespace VictoryRestaurant.API.Configurations;

public static class APIConfiguration
{
    public static void AddAPIConfiguration(this IServiceCollection services)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        services.AddTransient<IApi, FoodApi>();
        services.AddTransient<IApi, BookingApi>();
        services.AddTransient<IApi, ContactMessageApi>();
        services.AddTransient<IApi, MailSubscriberApi>();
        services.AddSingleton<IApi, UserApi>();
        services.AddSingleton<IApi, AuthorizationApi>();
    }
}