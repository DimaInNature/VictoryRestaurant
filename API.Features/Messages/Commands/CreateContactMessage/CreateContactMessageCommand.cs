namespace API.Features.Messages.Commands;

public sealed record class CreateContactMessageCommand : IRequest
{
    public ContactMessageEntity? ContactMessage { get; }

    public CreateContactMessageCommand(ContactMessageEntity contactMessage!!) => ContactMessage = contactMessage;

    public CreateContactMessageCommand() { }
}