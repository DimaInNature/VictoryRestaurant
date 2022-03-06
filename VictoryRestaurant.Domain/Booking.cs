namespace VictoryRestaurant.Domain;

public class Booking
{
    public int Id { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public string Time { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public int PersonCount { get; set; }
}