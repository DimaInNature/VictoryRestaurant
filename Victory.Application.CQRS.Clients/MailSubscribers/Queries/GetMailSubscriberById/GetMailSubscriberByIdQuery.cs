﻿namespace Victory.Application.CQRS.Clients.MailSubscribers;

public sealed record class GetMailSubscriberByIdQuery
    : BaseAuthorizedFeature, IRequest<MailSubscriber?>
{
    public int Id { get; }

    public GetMailSubscriberByIdQuery(int id, string token) => (Id, Token) = (id, token);

    public GetMailSubscriberByIdQuery() { }
}