namespace Victory.Application.General.Client.Features.ContactMessages;

public sealed record class GetContactMessageByIdQueryHandler
    : IRequestHandler<GetContactMessageByIdQuery, ContactMessage?>
{
    private readonly APIFeaturesConfigurationService _apiConfig;

    public GetContactMessageByIdQueryHandler(APIFeaturesConfigurationService apiConfig) =>
        _apiConfig = apiConfig;

    public async Task<ContactMessage?> Handle(GetContactMessageByIdQuery request, CancellationToken token)
    {
        using var httpClient = new HttpClient();

        using var response = await httpClient.GetAsync(
            requestUri: $"{_apiConfig.ServerUrl}/ContactMessages/{request.Id}",
            cancellationToken: token);

        string apiResponse = await response.Content.ReadAsStringAsync(cancellationToken: token);

        return JsonConvert.DeserializeObject<ContactMessage>(value: apiResponse);
    }
}