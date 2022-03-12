namespace API.Data.Repositories;

public class MailSubscriberRepository : IMailSubscriberRepository
{
    private readonly ApplicationContext _context;
    private bool _disposed = false;

    public MailSubscriberRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<List<MailSubscriberEntity>> GetMailSubscribersAsync() =>
        await _context.MailSubscribers.ToListAsync();

    public async Task<MailSubscriberEntity> GetMailSubscriberAsync(int mailSubscriberId) =>
         await _context.MailSubscribers.FindAsync(new object[] { mailSubscriberId });

    public async Task InsertMailSubscriberAsync(MailSubscriberEntity mailSubscriber) =>
        await _context.MailSubscribers.AddAsync(mailSubscriber);

    public async Task UpdateMailSubscriberAsync(MailSubscriberEntity mailSubscriber)
    {
        var mailSubscriberFromDb = await _context.MailSubscribers.FindAsync(new object[] { mailSubscriber.Id });

        if (mailSubscriberFromDb is null) return;

        mailSubscriberFromDb.Id = mailSubscriber.Id;
        mailSubscriberFromDb.Mail = mailSubscriber.Mail;
    }

    public async Task DeleteMailSubscriberAsync(int mailSubscriberId)
    {
        var mailSubscriberFromDb = await _context.MailSubscribers.FindAsync(new object[] { mailSubscriberId });

        if (mailSubscriberFromDb is null) return;

        _context.MailSubscribers.Remove(mailSubscriberFromDb);
    }

    public async Task<int> SaveAsync() => await _context.SaveChangesAsync();

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed is false)
            if (disposing)
                _context.Dispose();

        _disposed = true;
    }
}