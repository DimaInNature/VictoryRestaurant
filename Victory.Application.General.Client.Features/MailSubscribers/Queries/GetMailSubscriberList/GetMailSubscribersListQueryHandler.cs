namespace Victory.Application.General.Client.Features.MailSubscribers;

public sealed record class GetMailSubscribersListQueryHandler
    : IRequestHandler<GetMailSubscriberListQuery, List<MailSubscriber>?>
{
    private readonly APIFeaturesConfigurationService _apiConfig;

    public GetMailSubscribersListQueryHandler(APIFeaturesConfigurationService apiConfig) =>
        _apiConfig = apiConfig;

    public async Task<List<MailSubscriber>?> Handle(GetMailSubscriberListQuery request, CancellationToken token)
    {
        using var httpClient = new HttpClient();

        using var response = await httpClient.GetAsync(
            requestUri: $"{_apiConfig.ServerUrl}/MailSubscribers",
            cancellationToken: token);

        string apiResponse = await response.Content.ReadAsStringAsync(cancellationToken: token);

        return JsonConvert.DeserializeObject<List<MailSubscriber>>(value: apiResponse);
    }
}