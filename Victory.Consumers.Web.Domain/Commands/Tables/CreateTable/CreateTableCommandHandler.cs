namespace Victory.Consumers.Web.Domain.Commands.Tables;

public sealed record class CreateTableCommandHandler
    : IRequestHandler<CreateTableCommand>
{
    private readonly APIFeaturesConfigurationService _apiConfig;

    public CreateTableCommandHandler(APIFeaturesConfigurationService apiConfig) =>
        _apiConfig = apiConfig;

    public async Task<Unit> Handle(CreateTableCommand request, CancellationToken token)
    {
        if (string.IsNullOrWhiteSpace(value: request.Token)) return Unit.Value;

        using var httpClient = new HttpClient();

        httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue(
                scheme: "Bearer",
                parameter: request.Token);

        string json = JsonConvert.SerializeObject(value: request.Table);

        await httpClient.PostAsync(
            requestUri: $"{_apiConfig.ServerUrl}/Tables",
            content: new StringContent(
                content: json,
                encoding: Encoding.UTF8,
                mediaType: "application/json"),
            cancellationToken: token);

        return Unit.Value;
    }
}