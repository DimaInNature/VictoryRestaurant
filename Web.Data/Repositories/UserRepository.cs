namespace Web.Data.Repositories;

public class UserRepository : IUserRepository
{
    public async Task<UserEntity> GetUserAsync(string login)
    {
        using var httpClient = new HttpClient();
        using var response = await httpClient.GetAsync(requestUri: $"https://localhost:7059/Users/{login}");
        string apiResponse = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<UserEntity>(value: apiResponse);
    }

    public async Task<UserEntity> GetUserAsync(string login, string password)
    {
        using var httpClient = new HttpClient();
        using var response = await httpClient.GetAsync(requestUri: $"https://localhost:7059/Users/{login}And{password}");
        string apiResponse = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<UserEntity>(value: apiResponse);
    }

    public async Task InsertUserAsync(UserEntity user)
    {
        using var client = new HttpClient();

        string json = JsonConvert.SerializeObject(value: user);

        await client.PostAsync(
            requestUri: "https://localhost:7059/Users",
            content: new StringContent(
                content: json,
                encoding: Encoding.UTF8,
                mediaType: "application/json"));
    }
}