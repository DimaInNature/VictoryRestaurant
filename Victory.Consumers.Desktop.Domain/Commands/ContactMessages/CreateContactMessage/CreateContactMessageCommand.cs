namespace Victory.Consumers.Desktop.Domain.Commands.ContactMessages;

public sealed record class CreateContactMessageCommand
    : BaseAnonymousFeature, IRequest
{
    public ContactMessage? ContactMessage { get; }

    public CreateContactMessageCommand(ContactMessage entity) => ContactMessage = entity;

    public CreateContactMessageCommand() { }
}