namespace Victory.Application.General.Client.Features.Users;

public sealed record class GetUserByLoginAndPasswordQueryHandler
    : IRequestHandler<GetUserByLoginAndPasswordQuery, User?>
{
    public async Task<User?> Handle(GetUserByLoginAndPasswordQuery request, CancellationToken token)
    {
        using var httpClient = new HttpClient();

        using var response = await httpClient.GetAsync(
            requestUri: $"http://localhost:7059/Users/Login/{request.Login}/Password/{request.Password}",
            cancellationToken: token);

        string apiResponse = await response.Content.ReadAsStringAsync(cancellationToken: token);

        return JsonConvert.DeserializeObject<User>(value: apiResponse);
    }
}