namespace Victory.Domain.Interfaces.API.Cache;

public interface ICacheService<T> where T : class
{
    Task<T?> GetAsync(string key);
    Task<bool> SetAsync(string key, T? value);
    Task<bool> RemoveAsync(string key);
}