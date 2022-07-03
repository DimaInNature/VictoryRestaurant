namespace Victory.Application.CQRS.Clients.ContactMessages;

public sealed record class CreateContactMessageCommand : IRequest
{
    public ContactMessage? ContactMessage { get; }

    public CreateContactMessageCommand(ContactMessage entity) => ContactMessage = entity;

    public CreateContactMessageCommand() { }
}