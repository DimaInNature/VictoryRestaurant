namespace Victory.Application.General.Client.Services.Data.ContactMessages;

public sealed class ContactMessageRepositoryService : IContactMessageRepositoryService
{
    private readonly IMediator _mediator;

    public ContactMessageRepositoryService(IMediator mediator) => _mediator = mediator;

    public async Task<List<ContactMessage>> GetContactMessageListAsync() =>
        await _mediator.Send(request: new GetContactMessageListQuery()) ?? new();

    public async Task<ContactMessage?> GetContactMessageAsync(int id) =>
        await _mediator.Send(request: new GetContactMessageByIdQuery(id));

    public async Task DeleteAsync(int id) =>
        await _mediator.Send(request: new DeleteContactMessageCommand(id));
}