namespace Victory.Persistence.Entities;

public class BookingEntity
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public string Time { get; set; }

    public string Name { get; set; }

    public string Phone { get; set; }

    public int PersonCount { get; set; }

    [JsonIgnore]
    public TableEntity? Table { get; set; }
}