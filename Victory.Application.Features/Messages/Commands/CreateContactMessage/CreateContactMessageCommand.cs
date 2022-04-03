namespace Victory.Application.Features.Messages;

public sealed record class CreateContactMessageCommand : IRequest
{
    public ContactMessage? ContactMessage { get; }

    public CreateContactMessageCommand(ContactMessage entity) => ContactMessage = entity;

    public CreateContactMessageCommand() { }
}