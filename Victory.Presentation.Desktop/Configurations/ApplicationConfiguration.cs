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
            ApplicationSettings data = new(isEnable: AutoUpdateIsEnable,
                secondsTimeout: value);

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
            ApplicationSettings data = new(isEnable: value,
                secondsTimeout: AutoUpdateSecondsTimeout);

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

        public ApplicationSettings(bool isEnable, int secondsTimeout) =>
            (AutoUpdateIsEnable, AutoUpdateSecondsTimeout) = (isEnable, secondsTimeout);
    }
}