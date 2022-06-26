namespace Victory.Application.General.Client.Features.Tables;

public sealed record class CreateTableCommandHandler
    : IRequestHandler<CreateTableCommand>
{
    private readonly APIFeaturesConfigurationService _apiConfig;

    public CreateTableCommandHandler(APIFeaturesConfigurationService apiConfig) =>
        _apiConfig = apiConfig;

    public async Task<Unit> Handle(CreateTableCommand request, CancellationToken token)
    {
        using var client = new HttpClient();

        string json = JsonConvert.SerializeObject(value: request.Table);

        await client.PostAsync(
            requestUri: $"{_apiConfig.ServerUrl}/Tables",
            content: new StringContent(
                content: json,
                encoding: Encoding.UTF8,
                mediaType: "application/json"),
            cancellationToken: token);

        return Unit.Value;
    }
}