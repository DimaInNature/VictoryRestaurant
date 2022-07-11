namespace Victory.Domain.Features.Consumers.ContactMessages;

public sealed record class CreateContactMessageCommand
    : BaseAnonymousFeature, IRequest
{
    public ContactMessage? ContactMessage { get; }

    public CreateContactMessageCommand(ContactMessage entity) => ContactMessage = entity;

    public CreateContactMessageCommand() { }
}