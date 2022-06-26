namespace Victory.Application.General.Client.Features.Foods;

public sealed record class DeleteFoodCommandHandler
    : IRequestHandler<DeleteFoodCommand>
{
    private readonly APIFeaturesConfigurationService _apiConfig;

    public DeleteFoodCommandHandler(APIFeaturesConfigurationService apiConfig) =>
        _apiConfig = apiConfig;

    public async Task<Unit> Handle(DeleteFoodCommand request, CancellationToken token)
    {
        using var client = new HttpClient();

        string json = JsonConvert.SerializeObject(value: request.Id);

        await client.DeleteAsync(
            requestUri: $"{_apiConfig.ServerUrl}/Foods/Id={request.Id}",
            cancellationToken: token);

        return Unit.Value;
    }
}