namespace Victory.Consumers.Desktop.Infra.IoC.MediatR.Profiles;

internal static class SmtpApiMediatRProfile
{
    public static void AddSmtpApiMediatRProfile(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(argument: services);

        #region Commands

        // Send All

        services.AddScoped<IRequest, EmailSendAllCommand>();
        services.AddScoped<IRequestHandler<EmailSendAllCommand, Unit>, EmailSendAllCommandHandler>();

        #endregion
    }
}