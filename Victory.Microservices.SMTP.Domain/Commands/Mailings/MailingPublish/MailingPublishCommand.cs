namespace Victory.Microservices.SMTP.Domain.Commands.Mailings;

public sealed record class MailingPublishCommand : IRequest
{
    public EmailMessage? Message { get; init; }

	public MailingPublishCommand(EmailMessage entity) =>
        Message = entity;

	public MailingPublishCommand() { }
}