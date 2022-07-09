namespace Victory.Application.CQRS.Clients.MailSubscribers;

public sealed record class DeleteMailSubscriberCommandHandler
    : IRequestHandler<DeleteMailSubscriberCommand>
{
    private readonly APIFeaturesConfigurationService _apiConfig;

    public DeleteMailSubscriberCommandHandler(APIFeaturesConfigurationService apiConfig) =>
        _apiConfig = apiConfig;

    public async Task<Unit> Handle(DeleteMailSubscriberCommand request, CancellationToken token)
    {
        if (string.IsNullOrWhiteSpace(value: request.Token)) return Unit.Value;

        using var httpClient = new HttpClient();

        httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue(
                scheme: "Bearer",
                parameter: request.Token);

        string json = JsonConvert.SerializeObject(value: request.Id);

        await httpClient.DeleteAsync(
            requestUri: $"{_apiConfig.ServerUrl}/MailSubscribers/Id={request.Id}",
            cancellationToken: token);

        return Unit.Value;
    }
}