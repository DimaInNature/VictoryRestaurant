namespace Victory.Application.General.Client.Features.Bookings;

public sealed record class GetBookingByIdQueryHandler
    : IRequestHandler<GetBookingByIdQuery, Booking?>
{
    private readonly APIFeaturesConfigurationService _apiConfig;

    public GetBookingByIdQueryHandler(APIFeaturesConfigurationService apiConfig) =>
        _apiConfig = apiConfig;

    public async Task<Booking?> Handle(GetBookingByIdQuery request, CancellationToken token)
    {
        using var httpClient = new HttpClient();

        using var response = await httpClient.GetAsync(
            requestUri: $"{_apiConfig.ServerUrl}/Bookings/Id={request.Id}",
            cancellationToken: token);

        string apiResponse = await response.Content.ReadAsStringAsync(cancellationToken: token);

        return JsonConvert.DeserializeObject<Booking>(value: apiResponse);
    }
}