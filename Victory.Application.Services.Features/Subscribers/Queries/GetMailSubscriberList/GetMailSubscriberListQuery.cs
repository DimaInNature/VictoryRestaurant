﻿namespace Victory.Application.Services.Features.Subscribers;

public sealed record class GetMailSubscriberListQuery : IRequest<List<MailSubscriberEntity>?> { }