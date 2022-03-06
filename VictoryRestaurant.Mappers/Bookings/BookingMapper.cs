namespace VictoryRestaurant.Mappers.Bookings;

public static class BookingMapper
{
    public static BookingEntity ToEntity(this Booking bookingItem) =>
       bookingItem is not null ? new()
       {
           Id = bookingItem.Id,
           Name = bookingItem.Name,
           DayOfWeek = bookingItem.DayOfWeek,
           Time = bookingItem.Time,
           PersonCount = bookingItem.PersonCount,
           Phone = bookingItem.Phone
       }
       : throw new ArgumentNullException($"{nameof(BookingMapper)},{nameof(bookingItem)}");

    public static Booking ToDomain(this BookingEntity bookingModel) =>
       bookingModel is not null ? new()
       {
           Id = bookingModel.Id,
           Name = bookingModel.Name,
           DayOfWeek = bookingModel.DayOfWeek,
           Time = bookingModel.Time,
           PersonCount = bookingModel.PersonCount,
           Phone = bookingModel.Phone
       }
       : throw new ArgumentNullException($"{nameof(BookingMapper)},{nameof(bookingModel)}");

    public static async Task<Booking> ToDomain(this Task<BookingEntity> bookingModel) => await
      bookingModel is not null ? new()
      {
          Id = bookingModel.Result.Id,
          Name = bookingModel.Result.Name,
          DayOfWeek = bookingModel.Result.DayOfWeek,
          Time = bookingModel.Result.Time,
          PersonCount = bookingModel.Result.PersonCount,
          Phone = bookingModel.Result.Phone
      }
      : throw new ArgumentNullException($"{nameof(BookingMapper)},{nameof(bookingModel)}");
}
