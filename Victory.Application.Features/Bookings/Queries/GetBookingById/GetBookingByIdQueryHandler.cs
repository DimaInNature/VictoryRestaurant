namespace Victory.Application.Features.Bookings;

public sealed record class GetBookingByIdQueryHandler
    : IRequestHandler<GetBookingByIdQuery, Booking?>
{
    public async Task<Booking?> Handle(GetBookingByIdQuery request, CancellationToken token)
    {
        using var httpClient = new HttpClient();

        using var response = await httpClient.GetAsync(
            requestUri: $"https://localhost:7059/Bookings/{request.Id}",
            cancellationToken: token);

        string apiResponse = await response.Content.ReadAsStringAsync(cancellationToken: token);

        return JsonConvert.DeserializeObject<Booking>(value: apiResponse);
    }
}