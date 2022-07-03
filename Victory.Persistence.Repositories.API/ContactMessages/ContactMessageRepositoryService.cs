namespace Victory.Persistence.Repositories.API.ContactMessages;

public class ContactMessageRepositoryService : IContactMessageRepositoryService
{
    private readonly IMediator _mediator;

    public ContactMessageRepositoryService(IMediator mediator) => _mediator = mediator;

    public async Task<List<ContactMessageEntity>?> GetContactMessageListAsync() =>
        await _mediator.Send(request: new GetContactMessageListQuery());

    public async Task<ContactMessageEntity?> GetContactMessageAsync(int id) =>
         await _mediator.Send(request: new GetContactMessageByIdQuery(id));

    public async Task CreateAsync(ContactMessageEntity entity) =>
        await _mediator.Send(request: new CreateContactMessageCommand(entity));

    public async Task UpdateAsync(ContactMessageEntity entity) =>
        await _mediator.Send(request: new UpdateContactMessageCommand(entity));

    public async Task DeleteAsync(int id) =>
        await _mediator.Send(request: new DeleteContactMessageCommand(id));
}