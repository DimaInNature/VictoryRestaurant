namespace Victory.Services.API.Controllers;

[Produces(contentType: "application/json")]
[ApiController]
[Route(template: "[controller]")]
public class TablesController : ControllerBase
{
    private readonly ITableFacadeService _repository;

    public TablesController(ITableFacadeService repository) => _repository = repository;

    /// <summary>
    /// Получение списка всех столиков.
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     GET /Tables
    ///
    /// </remarks>
    /// <returns>Возвращает список всех столиков.</returns>
    /// <response code="200">Возвращает список столиков.</response>
    /// <response code="404">Если ничего не было найдено.</response>
    [Tags(tags: "Tables")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Table>>> GetList() =>
        await _repository.GetTableListAsync() is IEnumerable<Table> tables
        ? Ok(value: tables)
        : NotFound();

    /// <summary>
    /// Получение списка всех столиков по их номеру.
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     GET /Tables/Number=1
    ///
    /// </remarks>
    /// <returns>Возвращает список столиков.</returns>
    /// <response code="200">Возвращает список столиков.</response>
    /// <response code="404">Если ничего не было найдено.</response>
    [Tags(tags: "Tables")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet("Number={number}")]
    public async Task<ActionResult<IEnumerable<Table>>> GetList(int number) =>
        await _repository.GetTableListAsync(number) is IEnumerable<Table> tables
        ? Ok(value: tables)
        : NotFound();

    /// <summary>
    /// Получение списка всех столиков по их статусу.
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     GET /Tables/Status=True
    ///
    /// </remarks>
    /// <returns>Возвращает список столиков.</returns>
    /// <response code="200">Возвращает список столиков.</response>
    /// <response code="404">Если ничего не было найдено.</response>
    [Tags(tags: "Tables")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet("Status={status}")]
    public async Task<ActionResult<IEnumerable<Table>>> GetList(string status) =>
        await _repository.GetTableListAsync(status) is IEnumerable<Table> tables
        ? Ok(value: tables)
        : NotFound();

    /// <summary>
    /// Получение столика по его идентификатору.
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     GET /Tables/Id=1
    ///
    /// </remarks>
    /// <param name="id">Идентификатор столика.</param>
    /// <returns>Возвращает столик.</returns>
    /// <response code="200">Возвращает найденный столик.</response>
    /// <response code="404">Если ничего не было найдено.</response>
    [Tags(tags: "Tables")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet(template: "Id={id}")]
    public async Task<ActionResult<Table>> Get(int id) =>
        await _repository.GetTableAsync(id) is Table table
        ? Ok(value: table)
        : NotFound();

    /// <summary>
    /// Создание столика.
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     POST /Tables
    ///     {
    ///         "id": 0, (Автоинкремент)
    ///         "number": 1,
    ///         "isBooked": true
    ///     }
    ///
    /// </remarks>
    /// <returns>Возвращает созданный столик.</returns>
    /// <response code="201">Возвращает созданный столик.</response>
    /// <response code="400">Если произошла ошибка.</response>
    [Tags(tags: "Tables")]
    [ProducesResponseType(statusCode: StatusCodes.Status201Created)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<ActionResult<Table>> Create([FromBody] Table table)
    {
        if (table is not null) await _repository.CreateAsync(entity: table);

        return Ok();
    }

    /// <summary>
    /// Изменение столика.
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     PUT /Tables
    ///     {
    ///         "id": 1, (Id изменяемого объекта)
    ///         "number": 2,
    ///         "isBooked": true
    ///     }
    ///
    /// </remarks>
    /// <response code="204">Объект успешно изменён.</response>
    /// <response code="400">Если произошла ошибка.</response>
    [Tags(tags: "Tables")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [HttpPut]
    public async Task<ActionResult> Update([FromBody] Table table)
    {
        if (table is not null) await _repository.UpdateAsync(entity: table);

        return NoContent();
    }

    /// <summary>
    /// Удаление столика.
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     DELETE /Tables/Id=1
    ///
    /// </remarks>
    /// <response code="204">Объект успешно удалён.</response>
    /// <response code="400">Если произошла ошибка.</response>
    [Tags(tags: "Tables")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [HttpDelete(template: "Id={id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _repository.DeleteAsync(id);

        return NoContent();
    }
}