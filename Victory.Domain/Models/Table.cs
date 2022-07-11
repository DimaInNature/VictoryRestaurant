namespace Victory.Domain.Models;

public class Table : IDomainModel
{
    public int Id { get; set; }

    public int Number { get; set; }

    public string Status { get; set; }

    public int? BookingId { get; set; }

    public Booking? Booking { get; set; }
}