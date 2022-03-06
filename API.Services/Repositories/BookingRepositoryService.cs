namespace API.Services.Repositories;

public class BookingRepositoryService : IBookingRepositoryService
{
    private readonly IBookingRepository _repository;

    public BookingRepositoryService(IBookingRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<BookingEntity>> GetBookingsAsync() =>
       await _repository.GetBookingsAsync();

    public async Task<BookingEntity> GetBookingAsync(int bookingId) =>
         await _repository.GetBookingAsync(bookingId);

    public async Task InsertBookingAsync(BookingEntity booking) =>
        await _repository.InsertBookingAsync(booking);

    public async Task UpdateBookingAsync(BookingEntity booking) =>
        await _repository.UpdateBookingAsync(booking);

    public async Task DeleteBookingAsync(int bookingId) =>
        await _repository.DeleteBookingAsync(bookingId);

    public async Task SaveAsync() => await _repository.SaveAsync();
}
