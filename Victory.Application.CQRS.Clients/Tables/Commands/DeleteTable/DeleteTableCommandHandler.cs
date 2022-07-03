namespace Victory.Application.CQRS.Clients.Tables;

public sealed record class DeleteTableCommandHandler
    : IRequestHandler<DeleteTableCommand>
{
    private readonly APIFeaturesConfigurationService _apiConfig;

    public DeleteTableCommandHandler(APIFeaturesConfigurationService apiConfig) =>
        _apiConfig = apiConfig;

    public async Task<Unit> Handle(DeleteTableCommand request, CancellationToken token)
    {
        using var client = new HttpClient();

        string json = JsonConvert.SerializeObject(value: request.Id);

        await client.DeleteAsync(
            requestUri: $"{_apiConfig.ServerUrl}/Tables/Id={request.Id}",
            cancellationToken: token);

        return Unit.Value;
    }
}