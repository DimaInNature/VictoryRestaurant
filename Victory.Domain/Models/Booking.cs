namespace Victory.Domain.Models;

public class Booking : IDomainModel
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public string Time { get; set; }

    public string Name { get; set; }

    public string Phone { get; set; }

    public int PersonCount { get; set; }

    public virtual Table? Table { get; set; }
}