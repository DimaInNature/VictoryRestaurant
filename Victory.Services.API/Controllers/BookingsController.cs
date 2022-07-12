namespace Victory.Services.API.Controllers;

[Produces(contentType: "application/json")]
[ApiController]
[Route(template: "[controller]")]
public class BookingsController : ControllerBase
{
    private readonly IBookingRepositoryService _repository;

    public BookingsController(IBookingRepositoryService repository) => _repository = repository;

    /// <summary>
    /// Get all bookings.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /Bookings
    ///
    /// </remarks>
    /// <returns>Return all bookings.</returns>
    /// <response code="200">Bookings list.</response>
    /// <response code="404">Not found.</response>
    [Authorize]
    [Tags(tags: "Bookings")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookingEntity>>> GetList() =>
        await _repository.GetBookingListAsync() is IEnumerable<BookingEntity> bookings
        ? Ok(value: bookings)
        : NotFound();

    /// <summary>
    /// Get booking by Id.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /Booking/Id=1
    ///
    /// </remarks>
    /// <param name="id">Id.</param>
    /// <returns>Booking</returns>
    /// <response code="200">Booking</response>
    /// <response code="404">If the booking was not found.</response>
    [Authorize]
    [Tags(tags: "Bookings")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet(template: "Id={id}")]
    public async Task<ActionResult<BookingEntity>> Get(int id) =>
        await _repository.GetBookingAsync(id) is BookingEntity contactMessage
        ? Ok(value: contactMessage)
        : NotFound();

    /// <summary>
    /// Get Booking.Table by Id.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /Booking/Id=1/Table
    ///
    /// </remarks>
    /// <param name="id">Id</param>
    /// <returns>Booking</returns>
    /// <response code="200">Booking.</response>
    /// <response code="404">If the booking was not found.</response>
    [Authorize]
    [Tags(tags: "Bookings")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet(template: "Id={id}/Table")]
    public async Task<ActionResult<TableEntity>> GetTable(int id) =>
        await _repository.GetBookingTableAsync(id) is TableEntity table
        ? Ok(value: table)
        : NotFound();

    /// <summary>
    /// Create booking.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     POST /Bookings
    ///     {
    ///         "id": 0, (auto)
    ///         "date": (date),
    ///         "time": "10:00",
    ///         "name": "Dmitry",
    ///         "phone": "23-45-67",
    ///         "personCount": 2
    ///     }
    ///
    /// </remarks>
    /// <returns>Return created booking.</returns>
    /// <response code="201">Booking.</response>
    /// <response code="400">If an error has occurred</response>
    [AllowAnonymous]
    [Tags(tags: "Bookings")]
    [ProducesResponseType(statusCode: StatusCodes.Status201Created)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<ActionResult<BookingEntity>> Create([FromBody] BookingEntity booking)
    {
        if (booking is not null) await _repository.CreateAsync(entity: booking);

        return CreatedAtAction(nameof(Get), new { id = booking?.Id }, booking);
    }

    /// <summary>
    /// Update booking.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     PUT /Bookings
    ///     {
    ///         "id": 1,
    ///         "date": (date),
    ///         "time": "10:00",
    ///         "name": "Dmitry",
    ///         "phone": "23-45-67",
    ///         "personCount": 2
    ///     }
    ///
    /// </remarks>
    /// <response code="204">The object has been successfully modified.</response>
    /// <response code="400">If an error has occurred.</response>
    [Authorize]
    [Tags(tags: "Bookings")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [HttpPut]
    public async Task<ActionResult> Update([FromBody] BookingEntity booking)
    {
        if (booking is not null) await _repository.UpdateAsync(entity: booking);

        return NoContent();
    }

    /// <summary>
    /// Delete booking.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     DELETE /Bookings/Id=1
    ///
    /// </remarks>
    /// <response code="204">The object has been successfully deleted.</response>
    /// <response code="400">If an error has occurred</response>
    [Authorize]
    [Tags(tags: "Bookings")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [HttpDelete(template: "Id={id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _repository.DeleteAsync(id);

        return NoContent();
    }
}