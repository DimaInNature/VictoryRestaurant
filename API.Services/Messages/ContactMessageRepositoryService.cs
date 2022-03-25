namespace API.Services.ContactMessages;

public class ContactMessageRepositoryService : IContactMessageRepositoryService
{
    private readonly IMediator _mediator;

    public ContactMessageRepositoryService(IMediator mediator) => _mediator = mediator;

    public async Task<List<ContactMessageEntity>?> GetContactMessageListAsync() =>
        await _mediator.Send(request: new GetContactMessageListQuery());

    public async Task<ContactMessageEntity?> GetContactMessageAsync(int contactMessageId) =>
         await _mediator.Send(request: new GetContactMessageByIdQuery(id: contactMessageId));

    public async Task CreateAsync(ContactMessageEntity contactMessage) =>
        await _mediator.Send(request: new CreateContactMessageCommand(contactMessage: contactMessage));

    public async Task UpdateAsync(ContactMessageEntity contactMessage) =>
        await _mediator.Send(request: new UpdateContactMessageCommand(contactMessage: contactMessage));

    public async Task DeleteAsync(int contactMessageId) =>
        await _mediator.Send(request: new DeleteContactMessageCommand(id: contactMessageId));
}