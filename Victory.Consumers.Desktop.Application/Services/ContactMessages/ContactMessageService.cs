namespace Victory.Consumers.Desktop.Application.Services.ContactMessages;

public sealed class ContactMessageService : IContactMessageService
{
    private readonly IMediator _mediator;

    public ContactMessageService(IMediator mediator) => _mediator = mediator;

    public async Task<List<ContactMessage>> GetContactMessageListAsync(string token) =>
        await _mediator.Send(request: new GetContactMessageListQuery(token)) ?? new();

    public async Task<ContactMessage?> GetContactMessageAsync(int id, string token) =>
        await _mediator.Send(request: new GetContactMessageByIdQuery(id, token));

    public async Task CreateAsync(ContactMessage entity) =>
        await _mediator.Send(request: new CreateContactMessageCommand(entity));

    public async Task DeleteAsync(int id, string token) =>
        await _mediator.Send(request: new DeleteContactMessageCommand(id, token));
}