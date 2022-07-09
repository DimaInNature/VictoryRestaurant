namespace Victory.Application.CQRS.Clients.Users;

public sealed record class DeleteUserCommandHandler
    : IRequestHandler<DeleteUserCommand>
{
    private readonly APIFeaturesConfigurationService _apiConfig;

    public DeleteUserCommandHandler(APIFeaturesConfigurationService apiConfig) =>
        _apiConfig = apiConfig;

    public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken token)
    {
        if (string.IsNullOrWhiteSpace(value: request.Token)) return Unit.Value;

        using var httpClient = new HttpClient();

        httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue(
                scheme: "Bearer",
                parameter: request.Token);

        string json = JsonConvert.SerializeObject(value: request.Id);

        await httpClient.DeleteAsync(
            requestUri: $"{_apiConfig.ServerUrl}/Users/Id={request.Id}",
            cancellationToken: token);

        return Unit.Value;
    }
}