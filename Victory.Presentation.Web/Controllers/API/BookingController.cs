namespace Victory.Presentation.Web.Controllers.API;

public class BookingController : Controller
{
    [HttpPost("/Bookings")]
    public async Task<IActionResult> CreateBooking(
        [FromServices] IBookingFacadeService bookingService,
        [FromServices] ITableFacadeService tableService,
        DateTime date, string time, string name, string phone, int personCount)
    {
        // We get all the free tables

        var freeTables = await tableService.GetTableListAsync(status: "Свободен");

        // We check that there is at least one free table

        if (freeTables.Count > 0)
        {
            // Get first

            Table? freeTable = freeTables.FirstOrDefault();

            if (freeTable is null)
                return RedirectToAction(actionName: "InternalServerError", controllerName: "Error");

            Booking? booking = new()
            {
                Date = date,
                Time = time,
                Name = name,
                PersonCount = personCount,
                Phone = phone
            };

            // Create booking

            booking = await bookingService.CreateAsync(booking);

            if (booking is null)
                return RedirectToAction(actionName: "InternalServerError", controllerName: "Error");

            // Linking the order to the table

            (freeTable.BookingId, freeTable.Status) = (booking.Id, "Занят");

            // Save changes

            await tableService.UpdateAsync(freeTable);

            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        return RedirectToAction(actionName: "InternalServerError", controllerName: "Error");
    }
}