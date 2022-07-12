namespace Victory.Domain.Interfaces.Cache;

public interface IAsyncCacheService<T> where T : class
{
    Task<T?> GetAsync(string key);
    Task<bool> SetAsync(string key, T? value);
    Task<bool> RemoveAsync(string key);
}