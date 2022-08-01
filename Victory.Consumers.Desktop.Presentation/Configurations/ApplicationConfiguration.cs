namespace Victory.Consumers.Desktop.Presentation.Configurations;

internal static class ApplicationConfiguration
{
    public const string ConfigurationFilePath = @"appsettings.json";

    public static MailSMTPHostConfiguration MailSMTPHostAuth
    {
        get
        {
            string json = File.ReadAllText(path: ConfigurationFilePath);

            var result = JsonConvert.DeserializeObject<ApplicationSettings>(value: json);

            return result?.MailSMTPHost ?? new();
        }
        set
        {
            ApplicationSettings data = new(
                mailSMTPHost: value,
                imageHostAuth: ImageHostAuth,
                serverAPI: ServerAPI,
                web: Web);

            SerializeObject(data);
        }
    }

    public static ImageHostConfiguration ImageHostAuth
    {
        get
        {
            string json = File.ReadAllText(path: ConfigurationFilePath);

            var result = JsonConvert.DeserializeObject<ApplicationSettings>(value: json);

            return result?.ImageHostAuth ?? new();
        }
        set
        {
            ApplicationSettings data = new(
                mailSMTPHost: MailSMTPHostAuth,
                imageHostAuth: value,
                serverAPI: ServerAPI,
                web: Web);

            SerializeObject(data);
        }
    }

    public static ServerAPIConfiguration ServerAPI
    {
        get
        {
            string json = File.ReadAllText(path: ConfigurationFilePath);

            var result = JsonConvert.DeserializeObject<ApplicationSettings>(value: json);

            return result?.ServerAPI ?? new();
        }
        set
        {
            ApplicationSettings data = new(
                mailSMTPHost: MailSMTPHostAuth,
                imageHostAuth: ImageHostAuth,
                serverAPI: value,
                web: Web);

            SerializeObject(data);
        }
    }

    public static WebConfiguration Web
    {
        get
        {
            string json = File.ReadAllText(path: ConfigurationFilePath);

            var result = JsonConvert.DeserializeObject<ApplicationSettings>(value: json);

            return result?.Web ?? new();
        }
        set
        {
            ApplicationSettings data = new(
                mailSMTPHost: MailSMTPHostAuth,
                imageHostAuth: ImageHostAuth,
                serverAPI: ServerAPI,
                web: value);

            SerializeObject(data);
        }
    }

    public static void ConfigureAPI() => (System.Windows.Application.Current as App)?
        .ServiceProvider?.GetService<APIFeaturesConfigurationService>()?
        .ConfigureUrl(url: ServerAPI.Url);

    public static void ConfigureSMTP() => (System.Windows.Application.Current as App)?
        .ServiceProvider?.GetService<SMTPConfigurationService>()?
        .ConfigureSMTP(uri: MailSMTPHostAuth.Uri);

    private static void SerializeObject(object obj)
    {
        JsonSerializer serializer = new() { NullValueHandling = NullValueHandling.Ignore };

        serializer.Converters.Add(item: new JavaScriptDateTimeConverter());

        using var stream = new StreamWriter(path: ConfigurationFilePath);

        using var writer = new JsonTextWriter(textWriter: stream);

        serializer.Serialize(jsonWriter: writer, value: obj);
    }
}