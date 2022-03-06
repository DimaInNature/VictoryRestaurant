namespace Web.Data.Repositories;

public class BookingRepository : IBookingRepository
{
    public async Task InsertBookingAsync(BookingEntity booking)
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
}
