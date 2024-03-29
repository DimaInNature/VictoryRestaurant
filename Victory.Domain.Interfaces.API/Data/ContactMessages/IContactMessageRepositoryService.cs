﻿namespace Victory.Domain.Interfaces.API.Data.ContactMessages;

public interface IContactMessageRepositoryService
{
    Task<List<ContactMessageEntity>?> GetContactMessageListAsync();
    Task<ContactMessageEntity?> GetContactMessageAsync(int id);
    Task CreateAsync(ContactMessageEntity entity);
    Task UpdateAsync(ContactMessageEntity entity);
    Task DeleteAsync(int id);
}