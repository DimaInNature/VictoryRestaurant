namespace Desktop.Data.Repositories;

public class ContactMessageRepository : IContactMessageRepository
{
    private bool _disposed = false;

    public async Task<List<ContactMessage>> GetContactMessageListAsync()
    {
        using var httpClient = new HttpClient();

        using var response = await httpClient.GetAsync(requestUri: "https://localhost:7059/ContactMessages");

        string apiResponse = await response.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<List<ContactMessage>>(value: apiResponse) ?? new();
    }

    public async Task<ContactMessage> GetContactMessageAsync(int contactMessageId)
    {
        using var httpClient = new HttpClient();
        using var response = await httpClient.GetAsync(requestUri: $"https://localhost:7059/Bookings/{contactMessageId}");
        string apiResponse = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<ContactMessage>(value: apiResponse) ?? new();
    }

    public async Task DeleteAsync(int contactMessageId)
    {
        using var client = new HttpClient();

        string json = JsonConvert.SerializeObject(value: contactMessageId);

        await client.DeleteAsync(
            requestUri: $"https://localhost:7059/ContactMessages/{contactMessageId}");
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