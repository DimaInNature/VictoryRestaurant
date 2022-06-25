namespace Victory.Services.API.Configurations.MediatR.Profiles;

public static class MailSubscriberMediatRProfile
{
    public static void AddMailSubscriberMediatRProfile(this IServiceCollection services)
    {
        #region Queries

        // Get MailSubscriber by Id

        services.AddScoped<IRequest<MailSubscriber?>, GetMailSubscriberByIdQuery>();
        services.AddScoped<IRequestHandler<GetMailSubscriberByIdQuery, MailSubscriber?>, GetMailSubscriberByIdQueryHandler>();

        // Get List<MailSubscriber>

        services.AddScoped<IRequest<List<MailSubscriber>?>, GetMailSubscriberListQuery>();
        services.AddScoped<IRequestHandler<GetMailSubscriberListQuery, List<MailSubscriber>?>, GetMailSubscriberListQueryHandler>();

        #endregion

        #region Commands

        // Create

        services.AddScoped<IRequest, CreateMailSubscriberCommand>();
        services.AddScoped<IRequestHandler<CreateMailSubscriberCommand, Unit>, CreateMailSubscriberCommandHandler>();

        // Update by Id

        services.AddScoped<IRequest, UpdateMailSubscriberCommand>();
        services.AddScoped<IRequestHandler<UpdateMailSubscriberCommand, Unit>, UpdateMailSubscriberCommandHandler>();

        // Delete by Id

        services.AddScoped<IRequest, DeleteMailSubscriberCommand>();
        services.AddScoped<IRequestHandler<DeleteMailSubscriberCommand, Unit>, DeleteMailSubscriberCommandHandler>();

        #endregion
    }
}