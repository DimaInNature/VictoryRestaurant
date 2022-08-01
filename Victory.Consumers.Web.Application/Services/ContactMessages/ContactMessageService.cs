namespace Victory.Consumers.Web.Application.Services.ContactMessages;

public class ContactMessageService : IContactMessageService
{
    private readonly IMediator _mediator;

    public ContactMessageService(IMediator mediator) =>
        _mediator = mediator;

    public async Task CreateAsync(ContactMessage entity) =>
        await _mediator.Send(request: new CreateContactMessageCommand(entity));
}