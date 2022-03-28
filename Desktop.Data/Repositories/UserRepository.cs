using System.Text;

namespace Desktop.Data.Repositories;

public class UserRepository : IUserRepository
{
    private bool _disposed = false;

    public async Task<List<User>?> GetUserListAsync()
    {
        using var httpClient = new HttpClient();

        using var response = await httpClient.GetAsync(
            requestUri: "https://localhost:7059/Users");

        string apiResponse = await response.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<List<User>>(value: apiResponse);
    }

    public async Task<User?> GetUserAsync(string login)
    {
        using var httpClient = new HttpClient();

        using var response = await httpClient.GetAsync(
            requestUri: $"https://localhost:7059/Users/Login/{login}");

        string apiResponse = await response.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<User>(value: apiResponse);
    }

    public async Task<User?> GetUserAsync(string login, string password)
    {
        using var httpClient = new HttpClient();

        using var response = await httpClient.GetAsync(
            requestUri: $"https://localhost:7059/Users/Login/{login}/Password/{password}");

        string apiResponse = await response.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<User>(value: apiResponse);
    }

    public async Task CreateAsync(User user)
    {
        if (user is null) return;

        using var client = new HttpClient();

        string json = JsonConvert.SerializeObject(value: user);

        await client.PostAsync(
            requestUri: "https://localhost:7059/Users",
            content: new StringContent(
                content: json,
                encoding: Encoding.UTF8,
                mediaType: "application/json"));
    }

    public async Task UpdateAsync(User user)
    {
        if (user is null) return;

        using var client = new HttpClient();

        string json = JsonConvert.SerializeObject(value: user);

        await client.PutAsync(
            requestUri: "https://localhost:7059/Users",
            content: new StringContent(
                content: json,
                encoding: Encoding.UTF8,
                mediaType: "application/json"));
    }

    public async Task DeleteAsync(int userId)
    {
        using var client = new HttpClient();

        string json = JsonConvert.SerializeObject(value: userId);

        await client.DeleteAsync(
            requestUri: $"https://localhost:7059/Users/{userId}");
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed is false)
            if (disposing)
                Dispose();

        _disposed = true;
    }
}