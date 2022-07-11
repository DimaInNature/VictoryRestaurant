namespace Victory.Domain.Features.Consumers.Tables;

public sealed record class DeleteTableCommandHandler
    : IRequestHandler<DeleteTableCommand>
{
    private readonly APIFeaturesConfigurationService _apiConfig;

    public DeleteTableCommandHandler(APIFeaturesConfigurationService apiConfig) =>
        _apiConfig = apiConfig;

    public async Task<Unit> Handle(DeleteTableCommand request, CancellationToken token)
    {
        if (string.IsNullOrWhiteSpace(value: request.Token)) return Unit.Value;

        using var httpClient = new HttpClient();

        httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue(
                scheme: "Bearer",
                parameter: request.Token);

        string json = JsonConvert.SerializeObject(value: request.Id);

        await httpClient.DeleteAsync(
            requestUri: $"{_apiConfig.ServerUrl}/Tables/Id={request.Id}",
            cancellationToken: token);

        return Unit.Value;
    }
}