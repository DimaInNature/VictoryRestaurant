namespace Victory.Services.Api.Configurations;

public static class APIConfiguration
{
    public static void AddAPIConfiguration(this IServiceCollection services)
    {
        services.AddTransient<IApi, FoodApi>();
        services.AddTransient<IApi, BookingApi>();
        services.AddTransient<IApi, ContactMessageApi>();
        services.AddTransient<IApi, MailSubscriberApi>();
        services.AddSingleton<IApi, UserApi>();
    }
}