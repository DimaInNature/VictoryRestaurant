﻿namespace Victory.Application.Web.Data.Users;

public class UserRepositoryServiceLoggerDecorator
{
    private readonly IUserRepositoryService _repository;

    private readonly ILogger<UserRepositoryServiceLoggerDecorator> _logger;

    public UserRepositoryServiceLoggerDecorator(IUserRepositoryService repository,
        ILogger<UserRepositoryServiceLoggerDecorator> logger) =>
        (_repository, _logger) = (repository, logger);

    public async Task<List<User>> GetUserListAsync(string token)
    {
        List<User> result = new();

        try
        {
            result = await _repository.GetUserListAsync(token);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }

        return result;
    }

    public async Task<User?> GetUserAsync(string login, string token)
    {
        try
        {
            return await _repository.GetUserAsync(login, token);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);

            return null;
        }
    }

    public async Task<User?> GetUserAsync(UserLogin userLogin)
    {
        try
        {
            return await _repository.GetUserAsync(userLogin);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);

            return null;
        }
    }

    public async Task CreateAsync(User entity)
    {
        try
        {
            await _repository.CreateAsync(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
    }

    public async Task UpdateAsync(User entity, string token)
    {
        try
        {
            await _repository.UpdateAsync(entity, token);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
    }

    public async Task DeleteAsync(int id, string token)
    {
        try
        {
            await _repository.DeleteAsync(id, token);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
    }
}