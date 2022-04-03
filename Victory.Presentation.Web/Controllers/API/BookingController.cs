namespace Victory.Presentation.Web.Controllers.API;

public class BookingController : Controller
{
    private readonly IBookingFacadeService _bookingService;

    public BookingController(IBookingFacadeService bookingService) =>
        _bookingService = bookingService;

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

        await _bookingService.CreateAsync(booking);

        return RedirectToAction(actionName: "Index", controllerName: "Home");
    }
}