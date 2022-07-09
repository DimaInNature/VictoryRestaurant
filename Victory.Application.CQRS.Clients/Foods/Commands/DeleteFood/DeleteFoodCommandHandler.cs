namespace Victory.Application.CQRS.Clients.Foods;

public sealed record class DeleteFoodCommandHandler
    : IRequestHandler<DeleteFoodCommand>
{
    private readonly APIFeaturesConfigurationService _apiConfig;

    public DeleteFoodCommandHandler(APIFeaturesConfigurationService apiConfig) =>
        _apiConfig = apiConfig;

    public async Task<Unit> Handle(DeleteFoodCommand request, CancellationToken token)
    {
        if (string.IsNullOrWhiteSpace(value: request.Token)) return Unit.Value;

        using var httpClient = new HttpClient();

        httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue(
                scheme: "Bearer",
                parameter: request.Token);

        string json = JsonConvert.SerializeObject(value: request.Id);

        await httpClient.DeleteAsync(
            requestUri: $"{_apiConfig.ServerUrl}/Foods/Id={request.Id}",
            cancellationToken: token);

        return Unit.Value;
    }
}