namespace Victory.Services.API.Controllers;

[Produces(contentType: "application/json")]
[ApiController]
[Route(template: "[controller]")]
public class UserRolesController : ControllerBase
{
    private readonly IUserRoleFacadeService _repository;

    public UserRolesController(IUserRoleFacadeService repository) => _repository = repository;

    /// <summary>
    /// Получение списка всех пользовательских ролей.
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     GET /UserRoles
    ///
    /// </remarks>
    /// <returns>Возвращает список всех пользовательских ролей.</returns>
    /// <response code="200">Возвращает список пользовательских ролей.</response>
    /// <response code="404">Если ничего не было найдено.</response>
    [Tags(tags: "UserRoles")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserRole>>> GetList() =>
        await _repository.GetUserRoleListAsync() is IEnumerable<UserRole> userRoles
        ? Ok(value: userRoles)
        : NotFound();

    /// <summary>
    /// Получение списка всех пользовательских ролей по их наименованию.
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     GET /UserRoles/Name=Employee
    ///
    /// </remarks>
    /// <returns>Возвращает список пользовательских ролей.</returns>
    /// <response code="200">Возвращает список пользовательских ролей.</response>
    /// <response code="404">Если ничего не было найдено.</response>
    [Tags(tags: "UserRoles")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet("Name={name}")]
    public async Task<ActionResult<IEnumerable<UserRole>>> GetList(string name) =>
        await _repository.GetUserRoleListAsync(name) is IEnumerable<UserRole> userRoles
        ? Ok(value: userRoles)
        : NotFound();

    /// <summary>
    /// Получение пользовательской роли по её идентификатору.
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     GET /UserRoles/1
    ///
    /// </remarks>
    /// <param name="id">Идентификатор пользовательской роли.</param>
    /// <returns>Возвращает пользовательскую роль.</returns>
    /// <response code="200">Возвращает найденную пользовательскую роль.</response>
    /// <response code="404">Если ничего не было найдено.</response>
    [Tags(tags: "UserRoles")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet(template: "Id")]
    public async Task<ActionResult<UserRole>> Get(int id) =>
        await _repository.GetUserRoleAsync(id) is UserRole userRole
        ? Ok(value: userRole)
        : NotFound();

    /// <summary>
    /// Создание пользовательской роли.
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     POST /UserRoles
    ///     {
    ///         "id": 0, (Автоинкремент)
    ///         "name": "Client"
    ///     }
    ///
    /// </remarks>
    /// <returns>Возвращает созданную пользовательскую роль.</returns>
    /// <response code="201">Возвращает созданную пользовательскую роль.</response>
    /// <response code="400">Если произошла ошибка.</response>
    [Tags(tags: "UserRoles")]
    [ProducesResponseType(statusCode: StatusCodes.Status201Created)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<ActionResult<UserRole>> Create([FromBody] UserRole userRole)
    {
        if (userRole is not null) await _repository.CreateAsync(entity: userRole);

        return Ok();
    }

    /// <summary>
    /// Изменение пользовательской роли.
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     PUT /UserRoles
    ///     {
    ///         "id": 1, (Id изменяемого объекта)
    ///         "name": "Client"
    ///     }
    ///
    /// </remarks>
    /// <response code="204">Объект успешно изменён.</response>
    /// <response code="400">Если произошла ошибка.</response>
    [Tags(tags: "UserRoles")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [HttpPut]
    public async Task<ActionResult> Update([FromBody] UserRole userRole)
    {
        if (userRole is not null) await _repository.UpdateAsync(entity: userRole);

        return NoContent();
    }

    /// <summary>
    /// Удаление пользовательской роли.
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     DELETE /UserRoles/1
    ///
    /// </remarks>
    /// <response code="204">Объект успешно удалён.</response>
    /// <response code="400">Если произошла ошибка.</response>
    [Tags(tags: "UserRoles")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [HttpDelete(template: "Id={id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _repository.DeleteAsync(id);

        return NoContent();
    }
}