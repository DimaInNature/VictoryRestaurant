namespace Web.Data.Repositories;

public class MailSubscriberRepository : IMailSubscriberRepository
{
    public async Task InsertMailSubscriberAsync(MailSubscriberEntity mailSubscriber)
    {
        using var client = new HttpClient();

        string json = JsonConvert.SerializeObject(value: mailSubscriber);

        await client.PostAsync(
            requestUri: "https://localhost:7059/MailSubscribers",
            content: new StringContent(
                content: json,
                encoding: Encoding.UTF8,
                mediaType: "application/json"));
    }
}