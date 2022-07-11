namespace Victory.Persistence.Entities;

public class TableEntity
{
    public int Id { get; set; }

    public int Number { get; set; }

    public string Status { get; set; }

    public int? BookingId { get; set; }

    public BookingEntity? Booking { get; set; }
}