namespace Victory.Domain.Models;

public class MailSubscriber : IDomainModel
{
    public int Id { get; set; }

    public string Mail { get; set; } = string.Empty;
}