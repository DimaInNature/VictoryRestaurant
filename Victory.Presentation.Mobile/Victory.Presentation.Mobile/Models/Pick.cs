namespace Victory.Presentation.Mobile.Models;

internal sealed class Pick
{
    public string Title
    {
        get => _title ?? string.Empty;
        set => _title = value;
    }

    public string Image
    {
        get => _imagePath ?? string.Empty;
        set => _imagePath = value;
    }

    public string Description
    {
        get => _description ?? string.Empty;
        set => _description = value;
    }

    private string? _title;

    private string? _imagePath;

    private string? _description;
}