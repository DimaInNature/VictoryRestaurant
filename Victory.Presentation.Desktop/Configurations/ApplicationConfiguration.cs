namespace Victory.Presentation.Desktop.Configurations;

internal static class ApplicationConfiguration
{
    public const string ConfigurationFilePath = @"appsettings.json";

    public static int AutoUpdateSecondsTimeout
    {
        get
        {
            int defaultValue = 20;

            if (File.Exists(path: ConfigurationFilePath) is false) return defaultValue;

            string json = File.ReadAllText(path: ConfigurationFilePath);

            var result = JsonConvert.DeserializeObject<ApplicationSettings>(value: json);

            return result is not null
                ? result.AutoUpdateSecondsTimeout
                : defaultValue;
        }
        set
        {
            ApplicationSettings data = new(
                mailSenderUserName: MailSenderUserName,
                secondsTimeout: value,
                mailSenderPassword: MailSenderPassword,
                isEnable: AutoUpdateIsEnable);

            SerializeObject(data);
        }
    }

    public static bool AutoUpdateIsEnable
    {
        get
        {
            bool defaultValue = false;

            if (File.Exists(path: ConfigurationFilePath) is false) return defaultValue;

            string json = File.ReadAllText(path: ConfigurationFilePath);

            var result = JsonConvert.DeserializeObject<ApplicationSettings>(value: json);

            return result is not null
                ? result.AutoUpdateIsEnable
                : defaultValue;
        }
        set
        {
            ApplicationSettings data = new(
                mailSenderUserName: MailSenderUserName,
                secondsTimeout: AutoUpdateSecondsTimeout,
                mailSenderPassword: MailSenderPassword,
                isEnable: value);

            SerializeObject(data);
        }
    }

    public static string MailSenderUserName
    {
        get
        {
            string defaultValue = string.Empty;

            if (File.Exists(path: ConfigurationFilePath) is false) return defaultValue;

            string json = File.ReadAllText(path: ConfigurationFilePath);

            var result = JsonConvert.DeserializeObject<ApplicationSettings>(value: json);

            return result is not null
                ? result.MailSenderUserName
                : defaultValue;
        }
        set
        {
            ApplicationSettings data = new(
                mailSenderUserName: value,
                secondsTimeout: AutoUpdateSecondsTimeout,
                mailSenderPassword: MailSenderPassword,
                isEnable: AutoUpdateIsEnable);

            SerializeObject(data);
        }
    }

    public static string MailSenderPassword
    {
        get
        {
            string defaultValue = string.Empty;

            if (File.Exists(path: ConfigurationFilePath) is false) return defaultValue;

            string json = File.ReadAllText(path: ConfigurationFilePath);

            var result = JsonConvert.DeserializeObject<ApplicationSettings>(value: json);

            return result is not null
                ? result.MailSenderPassword
                : defaultValue;
        }
        set
        {
            ApplicationSettings data = new(
               mailSenderUserName: MailSenderUserName,
               secondsTimeout: AutoUpdateSecondsTimeout,
               mailSenderPassword: value,
               isEnable: AutoUpdateIsEnable);

            SerializeObject(data);
        }
    }

    private static void SerializeObject(object obj)
    {
        Newtonsoft.Json.JsonSerializer serializer = new() { NullValueHandling = NullValueHandling.Ignore };

        serializer.Converters.Add(item: new JavaScriptDateTimeConverter());

        using var stream = new StreamWriter(path: ConfigurationFilePath);

        using var writer = new JsonTextWriter(textWriter: stream);

        serializer.Serialize(jsonWriter: writer, value: obj);
    }

    [Serializable]
    private sealed record class ApplicationSettings
    {
        public bool AutoUpdateIsEnable { get; init; }
        public int AutoUpdateSecondsTimeout { get; init; }
        public string MailSenderUserName { get; init; }
        public string MailSenderPassword { get; init; }

        public ApplicationSettings(bool isEnable, int secondsTimeout,
            string mailSenderUserName, string mailSenderPassword)
        {
            (AutoUpdateIsEnable, AutoUpdateSecondsTimeout) = (isEnable, secondsTimeout);

            (MailSenderUserName, MailSenderPassword) = (mailSenderUserName, mailSenderPassword);
        }

    }
}