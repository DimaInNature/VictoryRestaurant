﻿namespace Victory.Application.General.Client.Services.Data.MailSubscribers;

public sealed class MailSubscriberRepositoryService : IMailSubscriberRepositoryService
{
    private readonly IMediator _mediator;

    public MailSubscriberRepositoryService(IMediator mediator) => _mediator = mediator;

    public async Task<List<MailSubscriber>> GetMailSubscriberListAsync() =>
        await _mediator.Send(request: new GetMailSubscriberListQuery()) ?? new();

    public async Task<MailSubscriber?> GetMailSubscriberAsync(int id) =>
        await _mediator.Send(request: new GetMailSubscriberByIdQuery(id));

    public async Task DeleteAsync(int id) =>
        await _mediator.Send(request: new DeleteMailSubscriberCommand(id));
}