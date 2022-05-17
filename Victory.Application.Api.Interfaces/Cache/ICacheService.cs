﻿namespace Victory.Application.Api.Interfaces.Cache;

public interface ICacheService<T> where T : class
{
    T Set(int key, T value);
    bool TryGet(int key, out T value);
    void Remove(int key);
}