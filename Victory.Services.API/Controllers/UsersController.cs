namespace Victory.Services.API.Controllers;

[Produces(contentType: "application/json")]
[ApiController]
[Route(template: "[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserFacadeService _repository;

    public UsersController(IUserFacadeService repository) => _repository = repository;

    /// <summary>
    /// Получение списка всех пользователей.
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     GET /Users
    ///
    /// </remarks>
    /// <returns>Возвращает список всех пользователей.</returns>
    /// <response code="200">Возвращает список пользователей.</response>
    /// <response code="404">Если ничего не было найдено.</response>
    [Tags(tags: "Users")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetList() =>
        await _repository.GetUserListAsync() is IEnumerable<User> users
        ? Ok(value: users)
        : NotFound();

    /// <summary>
    /// Получение пользователя по его идентификатору.
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     GET /Users/1
    ///
    /// </remarks>
    /// <param name="id">Идентификатор пользователя.</param>
    /// <returns>Возвращает пользователя.</returns>
    /// <response code="200">Возвращает найденного пользователя.</response>
    /// <response code="404">Если ничего не было найдено.</response>
    [Tags(tags: "Users")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet(template: "Id")]
    public async Task<ActionResult<User>> Get(int id) =>
        await _repository.GetUserAsync(id) is User user
        ? Ok(value: user)
        : NotFound();

    /// <summary>
    /// Получение пользователя по его Login.
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     GET /Users/Admin
    ///
    /// </remarks>
    /// <param name="login">Login пользователя.</param>
    /// <returns>Возвращает найденного пользователя.</returns>
    /// <response code="200">Возвращает найденного пользователя.</response>
    /// <response code="404">Если ничего не было найдено.</response>
    [Tags(tags: "Users")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet(template: "{login}")]
    public async Task<ActionResult<User>> Get(string login) =>
        await _repository.GetUserAsync(login) is User user
        ? Ok(value: user)
        : NotFound();

    /// <summary>
    /// Получение пользователя по его Login и Password.
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     GET /Users/Admin&#38;Password
    ///
    /// </remarks>
    /// <param name="login">Login пользователя.</param>
    /// <param name="password">Password пользователя.</param>
    /// <returns>Возвращает найденного пользователя.</returns>
    /// <response code="200">Возвращает найденного пользователя.</response>
    /// <response code="404">Если ничего не было найдено.</response>
    [Tags(tags: "Users")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet(template: "{login}&{password}")]
    public async Task<ActionResult<User>> Get(string login, string password) =>
        await _repository.GetUserAsync(login, password) is User user
        ? Ok(value: user)
        : NotFound();

    /// <summary>
    /// Создание пользователя.
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     POST /Users
    ///     {
    ///         "id": 0, (Автоинкремент)
    ///         "login": "Admin",
    ///         "password": "1234",
    ///         "role": 1
    ///     }
    ///
    /// </remarks>
    /// <returns>Возвращает созданного пользователя.</returns>
    /// <response code="201">Возвращает созданного пользователя.</response>
    /// <response code="400">Если произошла ошибка.</response>
    [Tags(tags: "Users")]
    [ProducesResponseType(statusCode: StatusCodes.Status201Created)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<ActionResult<User>> Create([FromBody] User user)
    {
        if (user is not null) await _repository.CreateAsync(entity: user);

        return Ok();
    }

    /// <summary>
    /// Изменение пользователя.
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     PUT /Users
    ///     {
    ///         "id": 1, (Id изменяемого объекта)
    ///         "login": "Admin",
    ///         "password": "1234",
    ///         "role": 1
    ///     }
    ///
    /// </remarks>
    /// <response code="204">Объект успешно изменён.</response>
    /// <response code="400">Если произошла ошибка.</response>
    [Tags(tags: "Users")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [HttpPut]
    public async Task<ActionResult> Update([FromBody] User users)
    {
        if (users is not null) await _repository.UpdateAsync(entity: users);

        return NoContent();
    }

    /// <summary>
    /// Удаление пользователя.
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     DELETE /Users/Id=1
    ///
    /// </remarks>
    /// <response code="204">Объект успешно удалён.</response>
    /// <response code="400">Если произошла ошибка.</response>
    [Tags(tags: "Users")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [HttpDelete(template: "Id={id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _repository.DeleteAsync(id);

        return NoContent();
    }
}