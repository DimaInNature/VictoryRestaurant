namespace Victory.Application.General.Client.Features.Bookings;

public sealed record class GetBookingListQueryHandler
    : IRequestHandler<GetBookingListQuery, List<Booking>?>
{
    private readonly APIFeaturesConfigurationService _apiConfig;

    public GetBookingListQueryHandler(APIFeaturesConfigurationService apiConfig) =>
        _apiConfig = apiConfig;

    public async Task<List<Booking>?> Handle(GetBookingListQuery request, CancellationToken token)
    {
        using var httpClient = new HttpClient();

        using var response = await httpClient.GetAsync(
            requestUri: $"{_apiConfig.ServerUrl}/Bookings",
            cancellationToken: token);

        string apiResponse = await response.Content.ReadAsStringAsync(cancellationToken: token);

        return JsonConvert.DeserializeObject<List<Booking>>(value: apiResponse) ?? new();
    }
}