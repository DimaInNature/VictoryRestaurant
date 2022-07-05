namespace Victory.Services.SMTP.Configurations.MediatR.Profiles;

public static class MailSubscriberMediatRProfile
{
    public static void AddMailSubscriberMediatRProfile(this IServiceCollection services)
    {
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