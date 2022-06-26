namespace Victory.Application.General.Client.Features.Bookings;

public sealed record class GetBookingTableByIdQueryHandler
    : IRequestHandler<GetBookingTableByIdQuery, Table?>
{
    private readonly APIFeaturesConfigurationService _apiConfig;

    public GetBookingTableByIdQueryHandler(APIFeaturesConfigurationService apiConfig) =>
        _apiConfig = apiConfig;

    public async Task<Table?> Handle(GetBookingTableByIdQuery request, CancellationToken token)
    {
        using var httpClient = new HttpClient();

        using var response = await httpClient.GetAsync(
            requestUri: $"{_apiConfig.ServerUrl}/Bookings/Id={request.Id}/Table",
            cancellationToken: token);

        string apiResponse = await response.Content.ReadAsStringAsync(cancellationToken: token);

        return JsonConvert.DeserializeObject<Table>(value: apiResponse);
    }
}