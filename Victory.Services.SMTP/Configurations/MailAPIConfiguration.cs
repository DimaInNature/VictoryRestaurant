namespace Victory.Services.SMTP.Configurations;

public static class MailAPIConfiguration
{
    public static string UserName { get; set; } = string.Empty;

    public static string Password { get; set; } = string.Empty;

    public static string Host { get; set; } = string.Empty;

    public static int Port { get; set; } = 1;

    public static void SetMailConfiguration(this WebApplicationBuilder builder)
    {
        if (builder is null) throw new ArgumentNullException(nameof(builder));

        UserName = builder.Configuration[key: "MailSMTPHostAuth:UserName"];
        Password = builder.Configuration[key: "MailSMTPHostAuth:Password"];
        Host = builder.Configuration[key: "MailSMTPHostSettings:Host"];
        Port = Convert.ToInt32(value: builder.Configuration[key: "MailSMTPHostSettings:Port"]);
    }

    public static void ConfigureMailAPI(this IApplicationBuilder services) =>
        services.ApplicationServices.GetService<SMTPConfigurationService>()?
        .ConfigureSMTP(UserName, Password, Host, Port);
}