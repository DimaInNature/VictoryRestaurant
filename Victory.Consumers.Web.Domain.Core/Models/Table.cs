namespace Victory.Consumers.Web.Domain.Core.Models;

public class Table
{
    public int Id { get; set; }

    public int Number { get; set; }

    public string Status { get; set; }

    public int? BookingId { get; set; }

    public Booking? Booking { get; set; }
}