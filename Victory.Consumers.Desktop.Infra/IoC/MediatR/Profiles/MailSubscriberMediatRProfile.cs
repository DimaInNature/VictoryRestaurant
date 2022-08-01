namespace Victory.Consumers.Desktop.Infra.IoC.MediatR.Profiles;

internal static class MailSubscriberMediatRProfile
{
    public static void AddMailSubscriberMediatRProfile(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(argument: services);

        #region Queries

        // Get List<MailSubscriber>

        services.AddScoped<IRequest<List<MailSubscriber>?>, GetMailSubscriberListQuery>();
        services.AddScoped<IRequestHandler<GetMailSubscriberListQuery, List<MailSubscriber>?>, GetMailSubscribersListQueryHandler>();

        // Get MailSubscriber by Id

        services.AddScoped<IRequest<MailSubscriber?>, GetMailSubscriberByIdQuery>();
        services.AddScoped<IRequestHandler<GetMailSubscriberByIdQuery, MailSubscriber?>, GetMailSubscriberByIdQueryHandler>();

        #endregion

        #region Commands

        // Create

        services.AddScoped<IRequest, CreateMailSubscriberCommand>();
        services.AddScoped<IRequestHandler<CreateMailSubscriberCommand, Unit>, CreateMailSubscriberCommandHandler>();

        // Delete by Id

        services.AddScoped<IRequest, DeleteMailSubscriberCommand>();
        services.AddScoped<IRequestHandler<DeleteMailSubscriberCommand, Unit>, DeleteMailSubscriberCommandHandler>();

        #endregion
    }
}