namespace Victory.Application.CQRS.Clients.MailSubscribers;

public sealed record class GetMailSubscriberByIdQueryHandler
    : IRequestHandler<GetMailSubscriberByIdQuery, MailSubscriber?>
{
    private readonly APIFeaturesConfigurationService _apiConfig;

    public GetMailSubscriberByIdQueryHandler(APIFeaturesConfigurationService apiConfig) =>
        _apiConfig = apiConfig;

    public async Task<MailSubscriber?> Handle(GetMailSubscriberByIdQuery request, CancellationToken token)
    {
        using var httpClient = new HttpClient();

        using var response = await httpClient.GetAsync(
            requestUri: $"{_apiConfig.ServerUrl}/MailSubscribers/Id={request.Id}",
            cancellationToken: token);

        string apiResponse = await response.Content.ReadAsStringAsync(cancellationToken: token);

        return JsonConvert.DeserializeObject<MailSubscriber>(value: apiResponse);
    }
}