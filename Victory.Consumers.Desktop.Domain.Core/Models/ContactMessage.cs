namespace Victory.Consumers.Desktop.Domain.Core.Models;

public class ContactMessage : IDomainModel
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Mail { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public string Message { get; set; } = string.Empty;
}