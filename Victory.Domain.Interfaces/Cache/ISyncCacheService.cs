namespace Victory.Domain.Interfaces.Cache;

public interface ISyncCacheService<T> where T : class
{
    T? Get(string key);
    bool Set(string key, T? value);
    bool Remove(string key);
}