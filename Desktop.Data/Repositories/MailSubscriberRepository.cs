namespace Desktop.Data.Repositories;

public class MailSubscriberRepository : IMailSubscriberRepository
{
    private bool _disposed = false;

    public async Task<List<MailSubscriber>> GetMailSubscriberListAsync()
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

    public async Task DeleteAsync(int mailSubscriberId)
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