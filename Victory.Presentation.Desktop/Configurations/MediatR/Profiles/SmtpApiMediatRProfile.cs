namespace Victory.Presentation.Desktop.Configurations.MediatR.Profiles;

public static class SmtpApiMediatRProfile
{
    public static void AddSmtpApiMediatRProfile(this IServiceCollection services)
    {
        #region Commands

        // Send All

        services.AddScoped<IRequest, EmailSendAllCommand>();
        services.AddScoped<IRequestHandler<EmailSendAllCommand, Unit>, EmailSendAllCommandHandler>();

        #endregion
    }
}