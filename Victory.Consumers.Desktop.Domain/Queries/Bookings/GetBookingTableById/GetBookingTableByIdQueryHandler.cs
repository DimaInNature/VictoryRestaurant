namespace Victory.Consumers.Desktop.Domain.Queries.Bookings;

public sealed record class GetBookingTableByIdQueryHandler
    : IRequestHandler<GetBookingTableByIdQuery, Table?>
{
    private readonly APIFeaturesConfigurationService _apiConfig;

    public GetBookingTableByIdQueryHandler(APIFeaturesConfigurationService apiConfig) =>
        _apiConfig = apiConfig;

    public async Task<Table?> Handle(
        GetBookingTableByIdQuery request,
        CancellationToken token)
    {
        if (string.IsNullOrWhiteSpace(value: request.Token)) return null;

        using var httpClient = new HttpClient();

        httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue(
                scheme: "Bearer",
                parameter: request.Token);

        using var response = await httpClient.GetAsync(
            requestUri: $"{_apiConfig.ServerUrl}/Bookings/Id={request.Id}/Table",
            cancellationToken: token);

        string apiResponse = await response.Content.ReadAsStringAsync(cancellationToken: token);

        return JsonConvert.DeserializeObject<Table>(value: apiResponse);
    }
}