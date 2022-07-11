namespace Victory.Domain.Features.API.ContactMessages;

public sealed record class UpdateContactMessageCommand : IRequest
{
    public ContactMessageEntity? ContactMessage { get; }

    public UpdateContactMessageCommand(ContactMessageEntity contactMessage) => ContactMessage = contactMessage;

    public UpdateContactMessageCommand() { }
}