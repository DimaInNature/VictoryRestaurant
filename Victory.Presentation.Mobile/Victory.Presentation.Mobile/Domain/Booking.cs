namespace Victory.Presentation.Mobile.Domain;

public sealed class Booking
{
    public int Id { get; }

    public DayOfWeek DayOfWeek
    {
        get => _dayOfWeek ?? DayOfWeek.Sunday;
        set => _dayOfWeek = value;
    }

    public string Time
    {
        get => _time ?? string.Empty;
        set => _time = value;
    }

    public string Name
    {
        get => _name ?? string.Empty;
        set => _name = value;
    }

    public string Phone
    {
        get => _phone ?? string.Empty;
        set => _phone = value;
    }

    public int PersonCount
    {
        get => _personCount ?? 1;
        set => _personCount = value;
    }

    private DayOfWeek? _dayOfWeek;

    private string? _time;

    private string? _name;

    private string? _phone;

    private int? _personCount;

    public static BookingBuilder GetBuilder() => new();
}