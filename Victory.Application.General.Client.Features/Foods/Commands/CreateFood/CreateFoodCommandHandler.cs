namespace Victory.Application.General.Client.Features.Foods;

public sealed record class CreateFoodCommandHandler
    : IRequestHandler<CreateFoodCommand>
{
    private readonly APIFeaturesConfigurationService _apiConfig;

    public CreateFoodCommandHandler(APIFeaturesConfigurationService apiConfig) =>
        _apiConfig = apiConfig;

    public async Task<Unit> Handle(CreateFoodCommand request, CancellationToken token)
    {
        if (request.Food is null) return Unit.Value;

        using var client = new HttpClient();

        string json = JsonConvert.SerializeObject(value: request.Food);

        await client.PostAsync(
            requestUri: $"{_apiConfig.ServerUrl}/Foods",
            content: new StringContent(
                content: json,
                encoding: Encoding.UTF8,
                mediaType: "application/json"),
            cancellationToken: token);

        return Unit.Value;
    }
}