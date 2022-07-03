namespace Victory.Application.CQRS.Clients.ContactMessages;

public sealed record class CreateContactMessageCommandHandler
    : IRequestHandler<CreateContactMessageCommand>
{
    private readonly APIFeaturesConfigurationService _apiConfig;

    public CreateContactMessageCommandHandler(APIFeaturesConfigurationService apiConfig) =>
        _apiConfig = apiConfig;

    public async Task<Unit> Handle(CreateContactMessageCommand request, CancellationToken token)
    {
        using var client = new HttpClient();

        string json = JsonConvert.SerializeObject(value: request.ContactMessage);

        await client.PostAsync(
            requestUri: $"{_apiConfig.ServerUrl}/ContactMessages",
            content: new StringContent(
                content: json,
                encoding: Encoding.UTF8,
                mediaType: "application/json"),
            cancellationToken: token);

        return Unit.Value;
    }
}