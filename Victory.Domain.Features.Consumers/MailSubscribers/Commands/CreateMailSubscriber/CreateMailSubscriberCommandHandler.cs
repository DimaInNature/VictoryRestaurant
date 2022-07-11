namespace Victory.Domain.Features.Consumers.MailSubscribers;

public sealed record class CreateMailSubscriberCommandHandler
    : IRequestHandler<CreateMailSubscriberCommand>
{
    private readonly APIFeaturesConfigurationService _apiConfig;

    public CreateMailSubscriberCommandHandler(APIFeaturesConfigurationService apiConfig) =>
        _apiConfig = apiConfig;

    public async Task<Unit> Handle(CreateMailSubscriberCommand request, CancellationToken token)
    {
        using var client = new HttpClient();

        string json = JsonConvert.SerializeObject(value: request.MailSubscriber);

        await client.PostAsync(
            requestUri: $"{_apiConfig.ServerUrl}/MailSubscribers",
            content: new StringContent(
                content: json,
                encoding: Encoding.UTF8,
                mediaType: "application/json"),
            cancellationToken: token);

        return Unit.Value;
    }
}