namespace Victory.Microservices.SMTP.Infra.IoC.MediatR.Profiles;

public static class MailingMediatRProfile
{
    public static void AddMailingMediatRProfile(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(argument: services);

        #region Commands

        services.AddTransient<IRequest<Unit>, MailingPublishCommand>();
        services.AddTransient<IRequestHandler<MailingPublishCommand, Unit>, MailingPublishCommandHandler>();

        #endregion

    }
}