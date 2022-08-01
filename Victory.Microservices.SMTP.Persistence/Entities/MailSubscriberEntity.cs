namespace Victory.Microservices.SMTP.Persistence.Entities;

public class MailSubscriberEntity : IDatabaseEntity
{
    public int Id { get; set; }

    public string Mail { get; set; }
}