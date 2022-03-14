namespace Web.Services.Authorization;

public class AuthorizationService : IAuthorizationService
{
    public async Task<HttpResponseMessage> GetToken(User user)
    {
        using var client = new HttpClient();

        string json = JsonConvert.SerializeObject(value: user);

        var token = await client.PostAsync(
            requestUri: "https://localhost:7059/Login",
            content: new StringContent(
                content: json,
                encoding: Encoding.UTF8,
                mediaType: "application/json"));

        return token;
    }
}