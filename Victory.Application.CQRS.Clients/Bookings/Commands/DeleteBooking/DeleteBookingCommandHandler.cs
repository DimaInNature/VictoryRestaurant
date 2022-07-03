namespace Victory.Application.CQRS.Clients.Bookings;

public sealed record class DeleteBookingCommandHandler
    : IRequestHandler<DeleteBookingCommand>
{
    private readonly APIFeaturesConfigurationService _apiConfig;

    public DeleteBookingCommandHandler(APIFeaturesConfigurationService apiConfig) =>
        _apiConfig = apiConfig;

    public async Task<Unit> Handle(DeleteBookingCommand request, CancellationToken token)
    {
        using var client = new HttpClient();

        string json = JsonConvert.SerializeObject(value: request.Id);

        await client.DeleteAsync(
            requestUri: $"{_apiConfig.ServerUrl}/Bookings/Id={request.Id}",
            cancellationToken: token);

        return Unit.Value;
    }
}