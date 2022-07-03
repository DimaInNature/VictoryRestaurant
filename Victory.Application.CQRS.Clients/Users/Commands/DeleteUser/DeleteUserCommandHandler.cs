namespace Victory.Application.CQRS.Clients.Users;

public sealed record class DeleteUserCommandHandler
    : IRequestHandler<DeleteUserCommand>
{
    private readonly APIFeaturesConfigurationService _apiConfig;

    public DeleteUserCommandHandler(APIFeaturesConfigurationService apiConfig) =>
        _apiConfig = apiConfig;

    public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken token)
    {
        using var client = new HttpClient();

        string json = JsonConvert.SerializeObject(value: request.Id);

        await client.DeleteAsync(
            requestUri: $"{_apiConfig.ServerUrl}/Users/Id={request.Id}",
            cancellationToken: token);

        return Unit.Value;
    }
}