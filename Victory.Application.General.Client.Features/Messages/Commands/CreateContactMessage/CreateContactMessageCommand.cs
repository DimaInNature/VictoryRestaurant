﻿namespace Victory.Application.General.Client.Features.Messages;

public sealed record class CreateContactMessageCommand : IRequest
{
    public ContactMessage? ContactMessage { get; }

    public CreateContactMessageCommand(ContactMessage entity) => ContactMessage = entity;

    public CreateContactMessageCommand() { }
}