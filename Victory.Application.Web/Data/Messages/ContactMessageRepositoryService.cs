namespace Victory.Application.Web.Data.Messages;

public class ContactMessageRepositoryService : IContactMessageRepositoryService
{
    private readonly IMediator _mediator;

    public ContactMessageRepositoryService(IMediator mediator) => _mediator = mediator;

    public async Task CreateAsync(ContactMessage entity) =>
        await _mediator.Send(request: new CreateContactMessageCommand(entity));
}