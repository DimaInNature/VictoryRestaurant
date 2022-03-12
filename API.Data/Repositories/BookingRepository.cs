namespace API.Data.Repositories;

public class BookingRepository : IBookingRepository
{
    private readonly ApplicationContext _context;
    private bool _disposed = false;

    public BookingRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<List<BookingEntity>> GetBookingsAsync() =>
        await _context.Bookings.ToListAsync();

    public async Task<BookingEntity> GetBookingAsync(int bookingId) =>
         await _context.Bookings.FindAsync(new object[] { bookingId });

    public async Task InsertBookingAsync(BookingEntity booking) =>
        await _context.Bookings.AddAsync(booking);

    public async Task UpdateBookingAsync(BookingEntity booking)
    {
        var bookingFromDb = await _context.Bookings.FindAsync(new object[] { booking.Id });

        if (bookingFromDb is null) return;

        bookingFromDb.Id = booking.Id;
        bookingFromDb.Name = booking.Name;
        bookingFromDb.Phone = booking.Phone;
        bookingFromDb.PersonCount = booking.PersonCount;
        bookingFromDb.Time = booking.Time;
        bookingFromDb.DayOfWeek = booking.DayOfWeek;
    }

    public async Task DeleteBookingAsync(int bookingId)
    {
        var bookingFromDb = await _context.Bookings.FindAsync(new object[] { bookingId });

        if (bookingFromDb is null) return;

        _context.Bookings.Remove(bookingFromDb);
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