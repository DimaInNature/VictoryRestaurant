﻿namespace API.Data.Repositories.Abstract;

public interface IContactMessageRepository : IDisposable
{
    Task<List<ContactMessageEntity>> GetContactMessagesAsync();
    Task<ContactMessageEntity> GetContactMessageAsync(int contactMessageId);
    Task InsertContactMessageAsync(ContactMessageEntity contactMessage);
    Task UpdateContactMessageAsync(ContactMessageEntity contactMessage);
    Task DeleteContactMessageAsync(int bookingId);
    Task SaveAsync();
}