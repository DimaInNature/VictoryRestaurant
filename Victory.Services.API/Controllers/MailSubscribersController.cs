namespace Victory.Services.API.Controllers;

[Produces(contentType: "application/json")]
[ApiController]
[Route(template: "[controller]")]
public class MailSubscribersController : ControllerBase
{
    private readonly IMailSubscriberFacadeService _repository;

    public MailSubscribersController(IMailSubscriberFacadeService repository) => _repository = repository;

    /// <summary>
    /// Получение списка всех подписчиков на почтовую рассылку.
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     GET /MailSubscribers
    ///
    /// </remarks>
    /// <returns>Возвращает список всех подписчиков на почтовую рассылку.</returns>
    /// <response code="200">Возвращает список подписчиков на почтовую рассылку.</response>
    /// <response code="404">Если ничего не было найдено.</response>
    [Tags(tags: "MailSubscribers")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MailSubscriber>>> GetList() =>
        await _repository.GetMailSubscriberListAsync() is IEnumerable<MailSubscriber> mailSubscribers
        ? Ok(value: mailSubscribers)
        : NotFound();

    /// <summary>
    /// Получение подписчика на почтовую рассылку по его идентификатору.
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     GET /MailSubscribers/1
    ///
    /// </remarks>
    /// <param name="id">Идентификатор подписчика.</param>
    /// <returns>Возвращает подписчика на почтовую рассылку.</returns>
    /// <response code="200">Возвращает найденного подписчика.</response>
    /// <response code="404">Если ничего не было найдено.</response>
    [Tags(tags: "MailSubscribers")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet(template: "Id={id}")]
    public async Task<ActionResult<MailSubscriber>> Get(int id) =>
        await _repository.GetMailSubscriberAsync(id) is MailSubscriber mailSubscribers
        ? Ok(value: mailSubscribers)
        : NotFound();

    /// <summary>
    /// Создание подписчика на почтовую рассылку.
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     POST /MailSubscribers
    ///     {
    ///         "id": 0, (Автоинкремент)
    ///         "mail": "example@bk.com"
    ///     }
    ///
    /// </remarks>
    /// <returns>Возвращает созданного подписчика.</returns>
    /// <response code="201">Возвращает созданное сообщение.</response>
    /// <response code="400">Если произошла ошибка.</response>
    [Tags(tags: "MailSubscribers")]
    [ProducesResponseType(statusCode: StatusCodes.Status201Created)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<ActionResult<MailSubscriber>> Create([FromBody] MailSubscriber mailSubscriber)
    {
        if (mailSubscriber is not null) await _repository.CreateAsync(entity: mailSubscriber);

        return Ok();
    }

    /// <summary>
    /// Изменение подписчика на почтовую рассылку.
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     PUT /MailSubscribers
    ///     {
    ///         "id": 1, (Id изменяемого объекта)
    ///         "mail": "example@bk.com"
    ///     }
    ///
    /// </remarks>
    /// <response code="204">Объект успешно изменён.</response>
    /// <response code="400">Если произошла ошибка.</response>
    [Tags(tags: "MailSubscribers")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [HttpPut]
    public async Task<ActionResult> Update([FromBody] MailSubscriber mailSubscriber)
    {
        if (mailSubscriber is not null) await _repository.UpdateAsync(entity: mailSubscriber);

        return NoContent();
    }

    /// <summary>
    /// Удаление подписчика на почтовую рассылку.
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     DELETE /MailSubscribers/1
    ///
    /// </remarks>
    /// <response code="204">Объект успешно удалён.</response>
    /// <response code="400">Если произошла ошибка.</response>
    [Tags(tags: "MailSubscribers")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [HttpDelete(template: "Id={id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _repository.DeleteAsync(id);

        return NoContent();
    }
}