namespace Victory.Application.CQRS.Clients.Integrations.SMTP;

public sealed record class EmailSendAllCommand : IRequest
{
    public EmailMessage? EmailMessage { get; }

    public EmailSendAllCommand(EmailMessage entity) => EmailMessage = entity;

    public EmailSendAllCommand() { }
}