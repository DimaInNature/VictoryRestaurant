namespace VictoryRestaurant.Util.Helpers;

public sealed class StringHelper
{
    public static bool StrIsNotNullOrWhiteSpace(params string[] strings) =>
        strings.All(stroke => string.IsNullOrWhiteSpace(stroke) is false);

    public static bool StrIsNullOrWhiteSpace(params string[] strings) =>
        strings.All(stroke => string.IsNullOrWhiteSpace(stroke));
}