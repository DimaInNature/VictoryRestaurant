namespace Victory.Application.General.Client.Features.ContactMessages;

public sealed record class GetContactMessageListQueryHandler
    : IRequestHandler<GetContactMessageListQuery, List<ContactMessage>?>
{
    private readonly APIFeaturesConfigurationService _apiConfig;

    public GetContactMessageListQueryHandler(APIFeaturesConfigurationService apiConfig) =>
        _apiConfig = apiConfig;

    public async Task<List<ContactMessage>?> Handle(GetContactMessageListQuery request, CancellationToken token)
    {
        using var httpClient = new HttpClient();

        using var response = await httpClient.GetAsync(
            requestUri: $"{_apiConfig.ServerUrl}/ContactMessages",
            cancellationToken: token);

        string apiResponse = await response.Content.ReadAsStringAsync(cancellationToken: token);

        return JsonConvert.DeserializeObject<List<ContactMessage>>(value: apiResponse);
    }
}