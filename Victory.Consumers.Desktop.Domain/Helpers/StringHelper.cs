namespace Victory.Consumers.Desktop.Domain.Helpers;

public sealed class StringHelper
{
    public static bool StrIsNotNullOrWhiteSpace(params string[] strings) =>
        strings.All(predicate: stroke => string.IsNullOrWhiteSpace(value: stroke) is false);

    public static bool StrIsNullOrWhiteSpace(params string[] strings) =>
        strings.All(predicate: stroke => string.IsNullOrWhiteSpace(value: stroke));
}