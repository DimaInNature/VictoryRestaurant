namespace Victory.Services.API.Controllers;

[Produces(contentType: "application/json")]
[ApiController]
[Route(template: "[controller]")]
public class ContactMessagesController : ControllerBase
{
    private readonly IContactMessageFacadeService _repository;

    public ContactMessagesController(IContactMessageFacadeService repository) => _repository = repository;

    /// <summary>
    /// Получение списка всех сообщений, которые пользователи оставили в форме обратной связи.
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     GET /ContactMessages
    ///
    /// </remarks>
    /// <returns>Возвращает список всех сообщений.</returns>
    /// <response code="200">Возвращает список сообщений.</response>
    /// <response code="404">Если ничего не было найдено.</response>
    [Tags(tags: "ContactMessages")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ContactMessage>>> GetList() =>
        await _repository.GetContactMessageListAsync() is IEnumerable<ContactMessage> contactMessages
        ? Ok(value: contactMessages)
        : NotFound();

    /// <summary>
    /// Получение сообщения, которые пользователь оставил в форме обратной связи по его идентификатору.
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     GET /ContactMessages/1
    ///
    /// </remarks>
    /// <param name="id">Идентификатор сообщения.</param>
    /// <returns>Возвращает сообщение.</returns>
    /// <response code="200">Возвращает найденное сообщение.</response>
    /// <response code="404">Если сообщение не было найдено.</response>
    [Tags(tags: "ContactMessages")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet(template: "Id={id}")]
    public async Task<ActionResult<ContactMessage>> Get(int id) =>
        await _repository.GetContactMessageAsync(id) is ContactMessage contactMessage
        ? Ok(value: contactMessage)
        : NotFound();

    /// <summary>
    /// Создание сообщения.
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     POST /ContactMessages
    ///     {
    ///         "id": 0, (Автоинкремент)
    ///         "name": "Oleg",
    ///         "mail": "example@bk.com",
    ///         "phone": "23-45-67",
    ///         "message": "MyMessage"
    ///     }
    ///
    /// </remarks>
    /// <returns>Возвращает созданное сообщение.</returns>
    /// <response code="201">Возвращает созданное сообщение.</response>
    /// <response code="400">Если произошла ошибка.</response>
    [Tags(tags: "ContactMessages")]
    [ProducesResponseType(statusCode: StatusCodes.Status201Created)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<ActionResult<ContactMessage>> Create([FromBody] ContactMessage contactMessage)
    {
        if (contactMessage is not null) await _repository.CreateAsync(entity: contactMessage);

        return Ok();
    }

    /// <summary>
    /// Изменение сообщения.
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     PUT /ContactMessages
    ///     {
    ///         "id": 1, (Id изменяемого объекта)
    ///         "name": "Oleg",
    ///         "mail": "example@bk.com",
    ///         "phone": "23-45-67",
    ///         "message": "MyMessage"
    ///     }
    ///
    /// </remarks>
    /// <response code="204">Объект успешно изменён.</response>
    /// <response code="400">Если произошла ошибка.</response>
    [Tags(tags: "ContactMessages")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [HttpPut]
    public async Task<ActionResult> Update([FromBody] ContactMessage contactMessage)
    {
        if (contactMessage is not null) await _repository.UpdateAsync(entity: contactMessage);

        return NoContent();
    }

    /// <summary>
    /// Удаление сообщения.
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     DELETE /ContactMessages/1
    ///
    /// </remarks>
    /// <response code="204">Объект успешно удалён.</response>
    /// <response code="400">Если произошла ошибка.</response>
    [Tags(tags: "ContactMessages")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [HttpDelete(template: "Id={id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _repository.DeleteAsync(id);

        return NoContent();
    }
}