namespace Web.Data.Repositories;

public class ContactMessageRepository : IContactMessageRepository
{
    public async Task InsertContactMessageAsync(ContactMessageEntity contactMessage)
    {
        using var client = new HttpClient();

        string json = JsonConvert.SerializeObject(value: contactMessage);

        await client.PostAsync(
            requestUri: "https://localhost:7059/ContactMessages",
            content: new StringContent(
                content: json,
                encoding: Encoding.UTF8,
                mediaType: "application/json"));
    }
}
