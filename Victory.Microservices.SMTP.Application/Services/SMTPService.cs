namespace Victory.Microservices.SMTP.Application.Services;

public class SMTPService : ISMTPService
{
    private readonly IMediator _mediator;

    public SMTPService(IMediator mediator) =>
        _mediator = mediator;

    public async Task SendAllAsync(EmailMessage message) =>
        await _mediator.Send(request: new MailingPublishCommand(message));
}