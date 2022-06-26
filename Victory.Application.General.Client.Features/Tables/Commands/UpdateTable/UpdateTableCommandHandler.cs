namespace Victory.Application.General.Client.Features.Tables;

public sealed record class UpdateTableCommandHandler
    : IRequestHandler<UpdateTableCommand>
{
    private readonly APIFeaturesConfigurationService _apiConfig;

    public UpdateTableCommandHandler(APIFeaturesConfigurationService apiConfig) =>
        _apiConfig = apiConfig;

    public async Task<Unit> Handle(UpdateTableCommand request, CancellationToken token)
    {
        if (request.Table is null) return Unit.Value;

        using var client = new HttpClient();

        string json = JsonConvert.SerializeObject(value: request.Table);

        await client.PutAsync(
            requestUri: $"{_apiConfig.ServerUrl}/Tables",
            content: new StringContent(
                content: json,
                encoding: Encoding.UTF8,
                mediaType: "application/json"),
            cancellationToken: token);

        return Unit.Value;
    }
}