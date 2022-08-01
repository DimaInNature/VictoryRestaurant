namespace Victory.Consumers.Web.Domain.Commands.Bookings;

public sealed record class CreateBookingCommandHandler
    : IRequestHandler<CreateBookingCommand, Booking?>
{
    private readonly APIFeaturesConfigurationService _apiConfig;

    public CreateBookingCommandHandler(APIFeaturesConfigurationService apiConfig) =>
        _apiConfig = apiConfig;

    public async Task<Booking?> Handle(
        CreateBookingCommand request,
        CancellationToken token)
    {
        using var httpClient = new HttpClient();

        string json = JsonConvert.SerializeObject(value: request.Booking);

        using var response = await httpClient.PostAsync(
            requestUri: $"{_apiConfig.ServerUrl}/Bookings",
            content: new StringContent(
                content: json,
                encoding: Encoding.UTF8,
                mediaType: "application/json"),
            cancellationToken: token);

        string apiResponse = await response.Content.ReadAsStringAsync(cancellationToken: token);

        return JsonConvert.DeserializeObject<Booking>(value: apiResponse);
    }
}