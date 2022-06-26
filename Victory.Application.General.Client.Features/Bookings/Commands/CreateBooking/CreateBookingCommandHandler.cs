namespace Victory.Application.General.Client.Features.Bookings;

public sealed record class CreateBookingCommandHandler
    : IRequestHandler<CreateBookingCommand>
{
    private readonly APIFeaturesConfigurationService _apiConfig;

    public CreateBookingCommandHandler(APIFeaturesConfigurationService apiConfig) =>
        _apiConfig = apiConfig;

    public async Task<Unit> Handle(CreateBookingCommand request, CancellationToken token)
    {
        using var client = new HttpClient();

        string json = JsonConvert.SerializeObject(value: request.Booking);

        await client.PostAsync(
            requestUri: $"{_apiConfig.ServerUrl}/Bookings",
            content: new StringContent(
                content: json,
                encoding: Encoding.UTF8,
                mediaType: "application/json"),
            cancellationToken: token);

        return Unit.Value;
    }
}