namespace Victory.Services.API.Controllers;

[Produces(contentType: "application/json")]
[ApiController]
[Route(template: "[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserFacadeService _repository;

    public UsersController(IUserFacadeService repository) => _repository = repository;

    /// <summary>
    /// Get all users.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /Users
    ///
    /// </remarks>
    /// <returns>Return all users.</returns>
    /// <response code="200">Users list.</response>
    /// <response code="404">If the users was not found.</response>
    [Authorize]
    [Tags(tags: "Users")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserEntity>>> GetList() =>
        await _repository.GetUserListAsync() is IEnumerable<UserEntity> users
        ? Ok(value: users)
        : NotFound();

    /// <summary>
    /// Get user by Id.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /Users/Id=1
    ///
    /// </remarks>
    /// <param name="id">Id.</param>
    /// <returns>User.</returns>
    /// <response code="200">User.</response>
    /// <response code="404">If the users was not found.</response>
    [Authorize]
    [Tags(tags: "Users")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet(template: "Id={id}")]
    public async Task<ActionResult<UserEntity>> Get(int id) =>
        await _repository.GetUserAsync(id) is UserEntity user
        ? Ok(value: user)
        : NotFound();

    /// <summary>
    /// Get user by Login.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /Users/Login=Admin
    ///
    /// </remarks>
    /// <param name="login">Login.</param>
    /// <returns>User.</returns>
    /// <response code="200">User.</response>
    /// <response code="404">If the user was not found.</response>
    [Authorize]
    [Tags(tags: "Users")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet(template: "Login={login}")]
    public async Task<ActionResult<UserEntity>> Get(string login) =>
        await _repository.GetUserAsync(login) is UserEntity user
        ? Ok(value: user)
        : NotFound();

    /// <summary>
    /// Get user by Login and Password.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /Users/Login=Admin&#38;Password=123456
    ///
    /// </remarks>
    /// <returns>User.</returns>
    /// <response code="200">User.</response>
    /// <response code="404">If the user was not found.</response>
    [AllowAnonymous]
    [Tags(tags: "Users")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet(template: "{login}&{password}")]
    public async Task<ActionResult<UserEntity>?> Get([FromHeader] UserLogin? userLogin)
    {
        if (userLogin is null) return null;

        var result = await _repository.GetUserAsync(userLogin);

        return result is UserEntity user
        ? Ok(value: user)
        : NotFound();
    }

    /// <summary>
    /// Create user.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     POST /Users
    ///     {
    ///         "id": 0, (auto)
    ///         "login": "Admin",
    ///         "password": "1234",
    ///         "userRoleId": 1
    ///     }
    ///
    /// </remarks>
    /// <returns>User.</returns>
    /// <response code="201">User.</response>
    /// <response code="400">If the user was not found.</response>
    [AllowAnonymous]
    [Tags(tags: "Users")]
    [ProducesResponseType(statusCode: StatusCodes.Status201Created)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<ActionResult<UserEntity>> Create([FromBody] UserEntity user)
    {
        if (user is not null) await _repository.CreateAsync(entity: user);

        return CreatedAtAction(nameof(Get), new { id = user?.Id }, user);
    }

    /// <summary>
    /// Update user.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     PUT /Users
    ///     {
    ///         "id": 1,
    ///         "login": "Admin",
    ///         "password": "1234",
    ///         "userRoleId": 1
    ///     }
    ///
    /// </remarks>
    /// <response code="204">The object has been successfully modified.</response>
    /// <response code="400">If an error has occurred.</response>
    [Authorize]
    [Tags(tags: "Users")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [HttpPut]
    public async Task<ActionResult> Update([FromBody] UserEntity users)
    {
        if (users is not null) await _repository.UpdateAsync(entity: users);

        return NoContent();
    }

    /// <summary>
    /// Delete user.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     DELETE /Users/Id=1
    ///
    /// </remarks>
    /// <response code="204">The object has been successfully deleted.</response>
    /// <response code="400">If an error has occurred.</response>
    [Authorize]
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