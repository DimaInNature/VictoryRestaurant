namespace Victory.Application.General.Client.Features.ContactMessages;

public sealed record class DeleteContactMessageCommandHandler
    : IRequestHandler<DeleteContactMessageCommand>
{
    private readonly APIFeaturesConfigurationService _apiConfig;

    public DeleteContactMessageCommandHandler(APIFeaturesConfigurationService apiConfig) =>
        _apiConfig = apiConfig;

    public async Task<Unit> Handle(DeleteContactMessageCommand request, CancellationToken token)
    {
        using var client = new HttpClient();

        string json = JsonConvert.SerializeObject(value: request.Id);

        await client.DeleteAsync(
            requestUri: $"{_apiConfig.ServerUrl}/ContactMessages/Id={request.Id}",
            cancellationToken: token);

        return Unit.Value;
    }
}