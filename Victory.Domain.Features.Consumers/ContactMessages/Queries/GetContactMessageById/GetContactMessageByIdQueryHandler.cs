namespace Victory.Domain.Features.Consumers.ContactMessages;

public sealed record class GetContactMessageByIdQueryHandler
    : IRequestHandler<GetContactMessageByIdQuery, ContactMessage?>
{
    private readonly APIFeaturesConfigurationService _apiConfig;

    public GetContactMessageByIdQueryHandler(APIFeaturesConfigurationService apiConfig) =>
        _apiConfig = apiConfig;

    public async Task<ContactMessage?> Handle(GetContactMessageByIdQuery request, CancellationToken token)
    {
        if (string.IsNullOrWhiteSpace(value: request.Token)) return null;

        using var httpClient = new HttpClient();

        httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue(
                scheme: "Bearer",
                parameter: request.Token);

        using var response = await httpClient.GetAsync(
            requestUri: $"{_apiConfig.ServerUrl}/ContactMessages/Id={request.Id}",
            cancellationToken: token);

        string apiResponse = await response.Content.ReadAsStringAsync(cancellationToken: token);

        return JsonConvert.DeserializeObject<ContactMessage>(value: apiResponse);
    }
}