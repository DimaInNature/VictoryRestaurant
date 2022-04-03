﻿namespace Victory.Application.Services.Features.Messages;

public sealed record class UpdateContactMessageCommand : IRequest
{
    public ContactMessageEntity? ContactMessage { get; }

    public UpdateContactMessageCommand(ContactMessageEntity contactMessage) => ContactMessage = contactMessage;

    public UpdateContactMessageCommand() { }
}