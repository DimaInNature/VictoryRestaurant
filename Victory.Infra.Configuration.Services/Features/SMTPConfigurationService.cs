namespace Victory.Infra.Configuration.Services.Features;

public class SMTPConfigurationService
{
    public string Uri { get; private set; } = string.Empty;

    public string UserName { get; private set; } = string.Empty;

    public string Password { get; private set; } = string.Empty;

    public string Host { get; private set; } = string.Empty;

    public int Port { get; private set; } = 1;

    public void ConfigureSMTP(string uri) => Uri = uri;

    public void ConfigureSMTP(string userName, string password, string host, int port) =>
       (UserName, Password, Host, Port) = (userName, password, host, port);
}