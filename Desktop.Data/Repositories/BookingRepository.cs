using System.Text;

namespace Desktop.Data.Repositories;

public class BookingRepository : IBookingRepository
{
    private bool _disposed = false;

    public async Task<List<Booking>> GetBookingsAsync()
    {
        using var httpClient = new HttpClient();
        using var response = await httpClient.GetAsync(requestUri: "https://localhost:7059/Bookings");
        string apiResponse = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<Booking>>(value: apiResponse) ?? new();
    }

    public async Task<Booking> GetBookingAsync(int bookingId)
    {
        using var httpClient = new HttpClient();
        using var response = await httpClient.GetAsync(requestUri: $"https://localhost:7059/Bookings/{bookingId}");
        string apiResponse = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<Booking>(value: apiResponse) ?? new();
    }

    public async Task InsertBookingAsync(Booking booking)
    {
        using var client = new HttpClient();

        string json = JsonConvert.SerializeObject(value: booking);

        await client.PostAsync(
            requestUri: "https://localhost:7059/Bookings",
            content: new StringContent(
                content: json,
                encoding: Encoding.UTF8,
                mediaType: "application/json"));
    }

    public async Task UpdateBookingAsync(Booking booking)
    {
        using var client = new HttpClient();

        string json = JsonConvert.SerializeObject(value: booking);

        await client.PutAsync(
            requestUri: "https://localhost:7059/Bookings",
            content: new StringContent(
                content: json,
                encoding: Encoding.UTF8,
                mediaType: "application/json"));
    }

    public async Task DeleteBookingAsync(int bookingId)
    {
        using var client = new HttpClient();

        string json = JsonConvert.SerializeObject(value: bookingId);

        await client.DeleteAsync(
            requestUri: $"https://localhost:7059/Bookings/{bookingId}");
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