namespace Victory.Consumers.Desktop.Application.Services.Integrations.SMTP;

public sealed class EmailService
{
    private readonly IMediator _mediator;

    public EmailService(IMediator mediator) => _mediator = mediator;

    public async Task SendAllAsync(EmailMessage message) =>
       await _mediator.Send(request: new EmailSendAllCommand(entity: message));
}