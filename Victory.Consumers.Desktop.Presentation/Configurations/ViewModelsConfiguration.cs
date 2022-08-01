namespace Victory.Consumers.Desktop.Presentation.Configurations;

internal static class ViewModelsConfiguration
{
    public static void AddViewModelsConfiguration(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(argument: services);

        services.AddTransient<LoginViewModel>();

        services.AddTransient<MainViewModel>();

        services.AddTransient<DeleteBookingsViewModel>();
        services.AddTransient<ReadBookingsViewModel>();

        services.AddTransient<DeleteContactMessagesViewModel>();
        services.AddTransient<ReadContactMessagesViewModel>();

        services.AddTransient<CreateFoodsViewModel>();
        services.AddTransient<DeleteFoodsViewModel>();
        services.AddTransient<ReadFoodsViewModel>();
        services.AddTransient<UpdateFoodsViewModel>();

        services.AddTransient<DeleteMailSubscribersViewModel>();
        services.AddTransient<ReadMailSubscribersViewModel>();
        services.AddTransient<SendMailSubscribersViewModel>();

        services.AddTransient<CreateTablesViewModel>();
        services.AddTransient<DeleteTablesViewModel>();
        services.AddTransient<ReadTablesViewModel>();
        services.AddTransient<UpdateTablesViewModel>();

        services.AddTransient<CreateUsersViewModel>();
        services.AddTransient<DeleteUsersViewModel>();
        services.AddTransient<ReadUsersViewModel>();
        services.AddTransient<UpdateUsersViewModel>();
    }
}