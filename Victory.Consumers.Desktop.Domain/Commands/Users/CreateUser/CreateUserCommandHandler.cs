namespace Victory.Consumers.Desktop.Domain.Commands.Users;

public sealed record class CreateUserCommandHandler
    : IRequestHandler<CreateUserCommand, User?>
{
    private readonly APIFeaturesConfigurationService _apiConfig;

    public CreateUserCommandHandler(APIFeaturesConfigurationService apiConfig) =>
        _apiConfig = apiConfig;

    public async Task<User?> Handle(CreateUserCommand request, CancellationToken token)
    {
        using var httpClient = new HttpClient();

        string json = JsonConvert.SerializeObject(value: request.User);

        using var response = await httpClient.PostAsync(
            requestUri: $"{_apiConfig.ServerUrl}/Users",
            content: new StringContent(
                content: json,
                encoding: Encoding.UTF8,
                mediaType: "application/json"),
            cancellationToken: token);

        string apiResponse = await response.Content.ReadAsStringAsync(cancellationToken: token);

        return JsonConvert.DeserializeObject<User?>(value: apiResponse);
    }
}