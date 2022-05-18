namespace Victory.Presentation.Desktop.Configurations;

internal static class DependencyInjectionConfiguration
{
    public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
    {
        if (services is null) throw new ArgumentNullException(nameof(services));

        services.AddScoped<IFoodRepositoryService, FoodRepositoryService>();
        services.AddTransient<IFoodFacadeService, FoodFacadeService>();

        services.AddScoped<IUserRepositoryService, UserRepositoryService>();
        services.AddTransient<IUserFacadeService, UserFacadeService>();

        services.AddScoped<IBookingRepositoryService, BookingRepositoryService>();
        services.AddTransient<IBookingFacadeService, BookingFacadeService>();

        services.AddScoped<IMailSubscriberRepositoryService, MailSubscriberRepositoryService>();
        services.AddTransient<IMailSubscriberFacadeService, MailSubscriberFacadeService>();

        services.AddScoped<IContactMessageRepositoryService, ContactMessageRepositoryService>();
        services.AddTransient<IContactMessageFacadeService, ContactMessageFacadeService>();

        services.AddTransient<EmailService>();
    }

    public static void AddViewModelsConfiguration(this IServiceCollection services)
    {
        if (services is null) throw new ArgumentNullException(nameof(services));

        services.AddTransient<ILoginViewModel, LoginViewModel>();

        services.AddTransient<IMainViewModel, MainViewModel>();

        services.AddTransient<IFoodsViewModel, FoodsViewModel>();
        services.AddTransient<IReadFoodsViewModel, ReadFoodsViewModel>();
        services.AddTransient<ICreateFoodsViewModel, CreateFoodsViewModel>();
        services.AddTransient<IUpdateFoodsViewModel, UpdateFoodsViewModel>();
        services.AddTransient<IDeleteFoodsViewModel, DeleteFoodsViewModel>();

        services.AddTransient<IUsersViewModel, UsersViewModel>();
        services.AddTransient<IReadUsersViewModel, ReadUsersViewModel>();
        services.AddTransient<ICreateUsersViewModel, CreateUsersViewModel>();
        services.AddTransient<IUpdateUsersViewModel, UpdateUsersViewModel>();
        services.AddTransient<IDeleteUsersViewModel, DeleteUsersViewModel>();

        services.AddTransient<IBookingsViewModel, BookingsViewModel>();
        services.AddTransient<IReadBookingsViewModel, ReadBookingsViewModel>();
        services.AddTransient<IDeleteBookingsViewModel, DeleteBookingsViewModel>();

        services.AddTransient<IMailSubscribersViewModel, MailSubscribersViewModel>();
        services.AddTransient<IReadMailSubscribersViewModel, ReadMailSubscribersViewModel>();
        services.AddTransient<IDeleteMailSubscribersViewModel, DeleteMailSubscribersViewModel>();
        services.AddTransient<ISendMailSubscribersViewModel, SendMailSubscribersViewModel>();

        services.AddTransient<IContactMessagesViewModel, ContactMessagesViewModel>();
        services.AddTransient<IReadContactMessagesViewModel, ReadContactMessagesViewModel>();
        services.AddTransient<IDeleteContactMessagesViewModel, DeleteContactMessagesViewModel>();

        services.AddSingleton<UserSessionService>();
    }
}