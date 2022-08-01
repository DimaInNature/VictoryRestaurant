namespace Victory.Consumers.Desktop.Domain.Core.Models;

public class Booking : IDomainModel
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public string Time { get; set; }

    public string Name { get; set; }

    public string Phone { get; set; }

    public int PersonCount { get; set; }

    public Table? Table { get; set; }
}