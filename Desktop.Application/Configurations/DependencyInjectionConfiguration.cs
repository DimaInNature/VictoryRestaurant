using Desktop.Services;

namespace Desktop.Presentation.Configurations;

internal static class DependencyInjectionConfiguration
{
    public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
    {
        if (services is null) throw new ArgumentNullException(nameof(services));

        NativeInjectorBootStrapper.RegisterServices(services);
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

        services.AddTransient<IContactMessagesViewModel, ContactMessagesViewModel>();
        services.AddTransient<IReadContactMessagesViewModel, ReadContactMessagesViewModel>();
        services.AddTransient<IDeleteContactMessagesViewModel, DeleteContactMessagesViewModel>();

        services.AddSingleton<UserSessionService>();
    }
}