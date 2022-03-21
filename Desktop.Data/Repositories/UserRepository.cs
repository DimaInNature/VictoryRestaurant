using System.Text;

namespace Desktop.Data.Repositories;

public class UserRepository : IUserRepository
{
    private bool _disposed = false;

    public async Task<List<User>> GetUsersAsync()
    {
        using var httpClient = new HttpClient();
        using var response = await httpClient.GetAsync(requestUri: "https://localhost:7059/Users");
        string apiResponse = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<User>>(value: apiResponse) ?? new();
    }

    public async Task<User> GetUserAsync(string login, string password)
    {
        using var httpClient = new HttpClient();
        using var response = await httpClient.GetAsync(requestUri: $"https://localhost:7059/{login}And{password}");
        string apiResponse = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<User>(value: apiResponse) ?? new();
    }

    public async Task InsertUserAsync(User user)
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

    public async Task UpdateUserAsync(User user)
    {
        using var client = new HttpClient();

        string json = JsonConvert.SerializeObject(value: user);

        await client.PutAsync(
            requestUri: "https://localhost:7059/Users",
            content: new StringContent(
                content: json,
                encoding: Encoding.UTF8,
                mediaType: "application/json"));
    }

    public async Task DeleteUserAsync(int userId)
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
