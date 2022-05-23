namespace Victory.Application.General.Client.Features.Users;

public sealed record class GetUserByLoginQueryHandler
    : IRequestHandler<GetUserByLoginQuery, User?>
{
    public async Task<User?> Handle(GetUserByLoginQuery request, CancellationToken token)
    {
        using var httpClient = new HttpClient();

        using var response = await httpClient.GetAsync(
            requestUri: $"http://localhost:7059/Users/{request.Login}",
            cancellationToken: token);

        string apiResponse = await response.Content.ReadAsStringAsync(cancellationToken: token);

        return JsonConvert.DeserializeObject<User>(value: apiResponse);
    }
}