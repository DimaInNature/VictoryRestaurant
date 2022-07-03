namespace Victory.Services.API.Configurations.MediatR.Profiles;

public static class MailSubscriberMediatRProfile
{
    public static void AddMailSubscriberMediatRProfile(this IServiceCollection services)
    {
        #region Queries

        // Get MailSubscriberEntity by Id

        services.AddScoped<IRequest<MailSubscriberEntity?>, GetMailSubscriberByIdQuery>();
        services.AddScoped<IRequestHandler<GetMailSubscriberByIdQuery, MailSubscriberEntity?>, GetMailSubscriberByIdQueryHandler>();

        // Get List<MailSubscriberEntity>

        services.AddScoped<IRequest<List<MailSubscriberEntity>?>, GetMailSubscriberListQuery>();
        services.AddScoped<IRequestHandler<GetMailSubscriberListQuery, List<MailSubscriberEntity>?>, GetMailSubscriberListQueryHandler>();

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