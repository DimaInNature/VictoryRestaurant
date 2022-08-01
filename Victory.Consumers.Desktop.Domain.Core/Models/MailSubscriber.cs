namespace Victory.Consumers.Desktop.Domain.Core.Models;

public class MailSubscriber : IDomainModel
{
    public int Id { get; set; }

    public string Mail { get; set; } = string.Empty;
}
