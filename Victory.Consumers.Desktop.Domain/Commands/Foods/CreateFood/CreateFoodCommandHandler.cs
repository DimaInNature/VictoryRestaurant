namespace Victory.Consumers.Desktop.Domain.Commands.Foods;

public sealed record class CreateFoodCommandHandler
    : IRequestHandler<CreateFoodCommand>
{
    private readonly APIFeaturesConfigurationService _apiConfig;

    public CreateFoodCommandHandler(APIFeaturesConfigurationService apiConfig) =>
        _apiConfig = apiConfig;

    public async Task<Unit> Handle(
        CreateFoodCommand request,
        CancellationToken token)
    {
        if (request.Food is null || string.IsNullOrWhiteSpace(value: request.Token))
            return Unit.Value;

        using var httpClient = new HttpClient();

        httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue(
                scheme: "Bearer",
                parameter: request.Token);

        string json = JsonConvert.SerializeObject(value: request.Food);

        await httpClient.PostAsync(
            requestUri: $"{_apiConfig.ServerUrl}/Foods",
            content: new StringContent(
                content: json,
                encoding: Encoding.UTF8,
                mediaType: "application/json"),
            cancellationToken: token);

        return Unit.Value;
    }
}