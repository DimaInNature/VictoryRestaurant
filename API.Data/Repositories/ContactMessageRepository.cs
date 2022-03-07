namespace API.Data.Repositories;

public class ContactMessageRepository : IContactMessageRepository
{
    private readonly ApplicationContext _context;

    public ContactMessageRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<List<ContactMessageEntity>> GetContactMessagesAsync() =>
        await _context.ContactMessages.ToListAsync();

    public async Task<ContactMessageEntity> GetContactMessageAsync(int contactMessageId) =>
         await _context.ContactMessages.FindAsync(new object[] { contactMessageId });

    public async Task InsertContactMessageAsync(ContactMessageEntity contactMessage) =>
        await _context.ContactMessages.AddAsync(contactMessage);

    public async Task UpdateContactMessageAsync(ContactMessageEntity contactMessage)
    {
        var contactMessageFromDb = await _context.ContactMessages.FindAsync(new object[] { contactMessage.Id });
        if (contactMessageFromDb is null) return;

        contactMessageFromDb.Id = contactMessage.Id;
        contactMessageFromDb.Phone = contactMessage.Phone;
        contactMessageFromDb.Message = contactMessage.Message;
        contactMessageFromDb.Mail = contactMessage.Mail;
        contactMessageFromDb.Name = contactMessage.Name;
    }

    public async Task DeleteContactMessageAsync(int contactMessageId)
    {
        var contactMessageFromDb = await _context.ContactMessages.FindAsync(new object[] { contactMessageId });
        if (contactMessageFromDb is null) return;
        _context.ContactMessages.Remove(contactMessageFromDb);
    }

    public async Task SaveAsync() => await _context.SaveChangesAsync();

    private bool _disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed is false)
        {
            if (disposing)
                _context.Dispose();
        }
        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}