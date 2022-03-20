namespace Web.Services.Messages;

public class ContactMessageRepositoryService : IContactMessageRepositoryService
{
    private readonly IContactMessageRepository _repository;
    private readonly IMapper _mapper;

    public ContactMessageRepositoryService(IMapper mapper,
        IContactMessageRepository repository)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task InsertContactMessageAsync(ContactMessage contactMessage) =>
        await _repository.InsertContactMessageAsync(
            contactMessage: _mapper.Map<ContactMessageEntity>(source: contactMessage));
}