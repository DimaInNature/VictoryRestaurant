﻿namespace API.Services.Abstract.Subscribers;

public interface IMailSubscriberFacadeService
{
    Task<List<MailSubscriberEntity>> GetMailSubscriberListAsync();
    Task<MailSubscriberEntity> GetMailSubscriberAsync(int mailSubscriberId);
    Task CreateAsync(MailSubscriberEntity mailSubscriber);
    Task UpdateAsync(MailSubscriberEntity mailSubscriber);
    Task DeleteAsync(int mailSubscriberId);
}