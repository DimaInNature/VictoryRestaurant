namespace Victory.Services.API.Controllers;

[Produces(contentType: "application/json")]
[ApiController]
[Route(template: "[controller]")]
public class BookingsController : ControllerBase
{
    private readonly IBookingFacadeService _repository;

    public BookingsController(IBookingFacadeService repository) => _repository = repository;

    /// <summary>
    /// Получение списка всех записей.
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     GET /Bookings
    ///
    /// </remarks>
    /// <returns>Возвращает список всех записей.</returns>
    /// <response code="200">Возвращает список записей.</response>
    /// <response code="404">Если ничего не было найдено.</response>
    [Tags(tags: "Bookings")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Booking>>> GetList() =>
        await _repository.GetBookingListAsync() is IEnumerable<Booking> bookings
        ? Ok(value: bookings)
        : NotFound();

    /// <summary>
    /// Получение записи по его идентификатору.
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     GET /Booking/1
    ///
    /// </remarks>
    /// <param name="id">Идентификатор записи.</param>
    /// <returns>Возвращает запись.</returns>
    /// <response code="200">Возвращает найденную запись.</response>
    /// <response code="404">Если запись не была найдена.</response>
    [Tags(tags: "Bookings")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet(template: "Id={id}")]
    public async Task<ActionResult<Booking>> Get(int id) =>
        await _repository.GetBookingAsync(id) is Booking contactMessage
        ? Ok(value: contactMessage)
        : NotFound();

    /// <summary>
    /// Получение стола заказа по идентификатору заказа.
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     GET /Booking/1
    ///
    /// </remarks>
    /// <param name="id">Идентификатор записи.</param>
    /// <returns>Возвращает запись.</returns>
    /// <response code="200">Возвращает найденную запись.</response>
    /// <response code="404">Если запись не была найдена.</response>
    [Tags(tags: "Bookings")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet(template: "Id={id}/Table")]
    public async Task<ActionResult<Table>> GetTable(int id) =>
        await _repository.GetBookingTableAsync(id) is Table table
        ? Ok(value: table)
        : NotFound();

    /// <summary>
    /// Создание записи.
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     POST /Bookings
    ///     {
    ///         "id": 0, (Автоинкремент)
    ///         "dayOfWeek": 0,
    ///         "time": "10:00",
    ///         "name": "Dmitry",
    ///         "phone": "23-45-67",
    ///         "personCount": 2
    ///     }
    ///
    /// </remarks>
    /// <returns>Возвращает созданное сообщение.</returns>
    /// <response code="201">Возвращает созданное сообщение.</response>
    /// <response code="400">Если произошла ошибка.</response>
    [Tags(tags: "Bookings")]
    [ProducesResponseType(statusCode: StatusCodes.Status201Created)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<ActionResult<Booking>> Create([FromBody] Booking booking)
    {
        if (booking is not null) await _repository.CreateAsync(entity: booking);

        return CreatedAtAction(nameof(Get), new { id = booking?.Id }, booking);
    }

    /// <summary>
    /// Изменение записи.
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     PUT /Bookings
    ///     {
    ///         "id": 1, (Id изменяемого объекта)
    ///         "dayOfWeek": 0,
    ///         "time": "10:00",
    ///         "name": "Dmitry",
    ///         "phone": "23-45-67",
    ///         "personCount": 2
    ///     }
    ///
    /// </remarks>
    /// <response code="204">Объект успешно изменён.</response>
    /// <response code="400">Если произошла ошибка.</response>
    [Tags(tags: "Bookings")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [HttpPut]
    public async Task<ActionResult> Update([FromBody] Booking booking)
    {
        if (booking is not null) await _repository.UpdateAsync(entity: booking);

        return NoContent();
    }

    /// <summary>
    /// Удаление записи.
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     DELETE /Bookings/1
    ///
    /// </remarks>
    /// <response code="204">Объект успешно удалён.</response>
    /// <response code="400">Если произошла ошибка.</response>
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