namespace Victory.Microservices.SMTP.Infra.IoC.MediatR.Profiles;

public static class MailSubscriberMediatRProfile
{
    public static void AddMailSubscriberMediatRProfile(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(argument: services);

        #region Commands

        services.AddTransient<IRequest<Unit>, CreateMailSubscriberCommand>();
        services.AddTransient<IRequestHandler<CreateMailSubscriberCommand, Unit>, CreateMailSubscriberCommandHandler>();

        services.AddTransient<IRequest<Unit>, UpdateMailSubscriberCommand>();
        services.AddTransient<IRequestHandler<UpdateMailSubscriberCommand, Unit>, UpdateMailSubscriberCommandHandler>();

        services.AddTransient<IRequest<Unit>, DeleteMailSubscriberCommand>();
        services.AddTransient<IRequestHandler<DeleteMailSubscriberCommand, Unit>, DeleteMailSubscriberCommandHandler>();

        #endregion

        #region Queries

        services.AddScoped<IRequest<MailSubscriberEntity?>, GetMailSubscriberByPredicateQuery>();
        services.AddScoped<IRequestHandler<GetMailSubscriberByPredicateQuery, MailSubscriberEntity?>, GetMailSubscriberByPredicateQueryHandler>();

        services.AddScoped<IRequest<IEnumerable<MailSubscriberEntity>>, GetMailSubscriberListQuery>();
        services.AddScoped<IRequestHandler<GetMailSubscriberListQuery, IEnumerable<MailSubscriberEntity>>, GetMailSubscriberListQueryHandler>();

        services.AddScoped<IRequest<IEnumerable<MailSubscriberEntity>>, GetMailSubscriberListByPredicateQuery>();
        services.AddScoped<IRequestHandler<GetMailSubscriberListByPredicateQuery, IEnumerable<MailSubscriberEntity>>, GetMailSubscriberListByPredicateQueryHandler>();

        #endregion
    }
}