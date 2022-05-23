namespace Victory.Presentation.Mobile.Domain;

public sealed class Food
{
    public int Id { get; }

    public string? Name
    {
        get => _name ?? "Название";
        set => _name = value;
    }

    public string? ImagePath
    {
        get => _imagePath ?? "IMG01.png";
        set => _imagePath = value;
    }

    public string? Description
    {
        get => _description ?? "Описание";
        set => _description = value;
    }

    public double? CostInUSD
    {
        get => _costInUSD ?? 10.99;
        set => _costInUSD = value;
    }

    private string? _name;

    private string? _imagePath;

    private string? _description;

    private double? _costInUSD;
}