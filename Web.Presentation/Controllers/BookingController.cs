namespace Web.Presentation.Controllers;

public class BookingController : Controller
{
    private readonly IBookingFacaceService _bookingService;

    public BookingController(IBookingFacaceService bookingService)
    {
        _bookingService = bookingService;
    }

    [HttpPost("/Bookings")]
    public async Task<IActionResult> CreateBooking(int dayOfWeek,
        string time, string name, string phone, int personCount)
    {
        Booking booking = new()
        {
            DayOfWeek = (DayOfWeek)dayOfWeek,
            Time = time,
            Name = name,
            PersonCount = personCount,
            Phone = phone
        };

        await _bookingService.InsertBookingAsync(booking);

        return RedirectToAction(actionName: "Index", controllerName: "Home");
    }
}
