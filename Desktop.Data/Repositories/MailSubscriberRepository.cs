using System.Text;

namespace Desktop.Data.Repositories;

public class MailSubscriberRepository : IMailSubscriberRepository
{
    private bool _disposed = false;

    public async Task<List<MailSubscriber>> GetMailSubscribersAsync()
    {
        using var httpClient = new HttpClient();
        using var response = await httpClient.GetAsync(requestUri: "https://localhost:7059/MailSubscribers");
        string apiResponse = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<MailSubscriber>>(value: apiResponse) ?? new();
    }

    public async Task<MailSubscriber> GetMailSubscriberAsync(int mailSubscriberId)
    {
        using var httpClient = new HttpClient();
        using var response = await httpClient.GetAsync(
            requestUri: $"https://localhost:7059/MailSubscribers/{mailSubscriberId}");
        string apiResponse = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<MailSubscriber>(value: apiResponse) ?? new();
    }

    public async Task InsertMailSubscriberAsync(MailSubscriber mailSubscriber)
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

    public async Task UpdateMailSubscriberAsync(MailSubscriber mailSubscriber)
    {
        using var client = new HttpClient();

        string json = JsonConvert.SerializeObject(value: mailSubscriber);

        await client.PutAsync(
            requestUri: "https://localhost:7059/MailSubscribers",
            content: new StringContent(
                content: json,
                encoding: Encoding.UTF8,
                mediaType: "application/json"));
    }

    public async Task DeleteMailSubscriberAsync(int mailSubscriberId)
    {
        using var client = new HttpClient();

        string json = JsonConvert.SerializeObject(value: mailSubscriberId);

        await client.DeleteAsync(
            requestUri: $"https://localhost:7059/MailSubscribers/{mailSubscriberId}");
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed is false)
            if (disposing)
                Dispose();

        _disposed = true;
    }
}