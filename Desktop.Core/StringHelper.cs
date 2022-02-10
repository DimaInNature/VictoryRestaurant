namespace Desktop.Core;

public static class StringHelper
{
    public static bool StrIsNotNullOrWhiteSpace(params string[] stringsArray) =>
        stringsArray.All(stroke => !string.IsNullOrWhiteSpace(stroke));

    public static bool StrIsNullOrWhiteSpace(params string[] stringsArray) =>
        stringsArray.All(stroke => string.IsNullOrWhiteSpace(stroke));
}
