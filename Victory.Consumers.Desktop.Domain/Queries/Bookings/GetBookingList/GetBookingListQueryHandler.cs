namespace Victory.Consumers.Desktop.Domain.Queries.Bookings;

public sealed record class GetBookingListQueryHandler
    : IRequestHandler<GetBookingListQuery, List<Booking>?>
{
    private readonly APIFeaturesConfigurationService _apiConfig;

    public GetBookingListQueryHandler(APIFeaturesConfigurationService apiConfig) =>
        _apiConfig = apiConfig;

    public async Task<List<Booking>?> Handle(
        GetBookingListQuery request,
        CancellationToken token)
    {
        if (string.IsNullOrWhiteSpace(value: request.Token)) return new();

        using var httpClient = new HttpClient();

        httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue(
                scheme: "Bearer",
                parameter: request.Token);

        using var response = await httpClient.GetAsync(
            requestUri: $"{_apiConfig.ServerUrl}/Bookings",
            cancellationToken: token);

        string apiResponse = await response.Content.ReadAsStringAsync(cancellationToken: token);

        return JsonConvert.DeserializeObject<List<Booking>>(value: apiResponse) ?? new();
    }
}