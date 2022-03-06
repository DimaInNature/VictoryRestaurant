namespace Web.Data.Repositories.Abstract;

public interface IBookingRepository
{
    Task InsertBookingAsync(BookingEntity booking);
}