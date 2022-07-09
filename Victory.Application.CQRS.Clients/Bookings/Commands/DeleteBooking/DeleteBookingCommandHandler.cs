namespace Victory.Application.CQRS.Clients.Bookings;

public sealed record class DeleteBookingCommandHandler
    : IRequestHandler<DeleteBookingCommand>
{
    private readonly APIFeaturesConfigurationService _apiConfig;

    public DeleteBookingCommandHandler(APIFeaturesConfigurationService apiConfig) =>
        _apiConfig = apiConfig;

    public async Task<Unit> Handle(DeleteBookingCommand request, CancellationToken token)
    {
        if (string.IsNullOrWhiteSpace(value: request.Token)) return Unit.Value;

        using var httpClient = new HttpClient();

        httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue(
                scheme: "Bearer",
                parameter: request.Token);

        string json = JsonConvert.SerializeObject(value: request.Id);

        await httpClient.DeleteAsync(
            requestUri: $"{_apiConfig.ServerUrl}/Bookings/Id={request.Id}",
            cancellationToken: token);

        return Unit.Value;
    }
}