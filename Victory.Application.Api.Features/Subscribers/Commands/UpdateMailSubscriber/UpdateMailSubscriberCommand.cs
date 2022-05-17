﻿namespace Victory.Application.Api.Features.Subscribers;

public sealed record class UpdateMailSubscriberCommand : IRequest
{
    public MailSubscriberEntity? MailSubscriber { get; }

    public UpdateMailSubscriberCommand(MailSubscriberEntity mailSubscriber) => MailSubscriber = mailSubscriber;

    public UpdateMailSubscriberCommand() { }
}