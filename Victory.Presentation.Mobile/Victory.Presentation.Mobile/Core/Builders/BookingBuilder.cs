namespace Victory.Presentation.Mobile.Core.Builders;

public sealed class BookingBuilder
{
    private readonly Booking _booking = new();

    public BookingBuilder SetTime(string time)
    {
        _booking.Time = time;

        return this;
    }

    public BookingBuilder SetName(string name)
    {
        _booking.Name = name;

        return this;
    }

    public BookingBuilder SetPhone(string phone)
    {
        _booking.Phone = phone;

        return this;
    }

    public BookingBuilder SetPersonCount(string countStr)
    {
        _booking.PersonCount = countStr switch
        {
            "1 человек" => 1,
            "2 человека" => 2,
            "3 человека" => 3,
            "4 человека" => 4,
            "5 человек" => 5,
            _ => 6
        };

        return this;
    }

    public BookingBuilder SetDayOfWeek(string dayOfWeek)
    {
        _booking.DayOfWeek = dayOfWeek switch
        {
            "Понедельник" => DayOfWeek.Sunday,
            "Вторник" => DayOfWeek.Monday,
            "Среда" => DayOfWeek.Tuesday,
            "Четверг" => DayOfWeek.Wednesday,
            "Пятница" => DayOfWeek.Thursday,
            "Суббота" => DayOfWeek.Friday,
            _ => DayOfWeek.Saturday,
        };

        return this;
    }

    public Booking Build() => _booking;
}