namespace Victory.Application.General.Client.Features.MailSubscribers;

public sealed record class DeleteMailSubscriberCommandHandler
    : IRequestHandler<DeleteMailSubscriberCommand>
{
    private readonly APIFeaturesConfigurationService _apiConfig;

    public DeleteMailSubscriberCommandHandler(APIFeaturesConfigurationService apiConfig) =>
        _apiConfig = apiConfig;

    public async Task<Unit> Handle(DeleteMailSubscriberCommand request, CancellationToken token)
    {
        using var client = new HttpClient();

        string json = JsonConvert.SerializeObject(value: request.Id);

        await client.DeleteAsync(
            requestUri: $"{_apiConfig.ServerUrl}/MailSubscribers/Id={request.Id}",
            cancellationToken: token);

        return Unit.Value;
    }
}