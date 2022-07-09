namespace Victory.Services.API.Controllers;

[Produces(contentType: "application/json")]
[ApiController]
[Route(template: "[controller]")]
public class UserRolesController : ControllerBase
{
    private readonly IUserRoleFacadeService _repository;

    public UserRolesController(IUserRoleFacadeService repository) => _repository = repository;

    /// <summary>
    /// Get all user roles.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /UserRoles
    ///
    /// </remarks>
    /// <returns>Return all user roles.</returns>
    /// <response code="200">User role list.</response>
    /// <response code="404">If the user roles was not found.</response>
    [Authorize]
    [Tags(tags: "UserRoles")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserRoleEntity>>> GetList() =>
        await _repository.GetUserRoleListAsync() is IEnumerable<UserRoleEntity> userRoles
        ? Ok(value: userRoles)
        : NotFound();

    /// <summary>
    /// Get all user roles by name.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /UserRoles/Name=Employee
    ///
    /// </remarks>
    /// <returns>User roles list.</returns>
    /// <response code="200">User roles list.</response>
    /// <response code="404">If the user roles was not found.</response>
    [Authorize]
    [Tags(tags: "UserRoles")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet("Name={name}")]
    public async Task<ActionResult<IEnumerable<UserRoleEntity>>> GetList(string name) =>
        await _repository.GetUserRoleListAsync(name) is IEnumerable<UserRoleEntity> userRoles
        ? Ok(value: userRoles)
        : NotFound();

    /// <summary>
    /// Get user role.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /UserRoles/Id=1
    ///
    /// </remarks>
    /// <param name="id">Id.</param>
    /// <returns>User role.</returns>
    /// <response code="200">User role.</response>
    /// <response code="404">If the user role was not found.</response>
    [Authorize]
    [Tags(tags: "UserRoles")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet(template: "Id={id}")]
    public async Task<ActionResult<UserRoleEntity>> Get(int id) =>
        await _repository.GetUserRoleAsync(id) is UserRoleEntity userRole
        ? Ok(value: userRole)
        : NotFound();

    /// <summary>
    /// Create user role.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     POST /UserRoles
    ///     {
    ///         "id": 0, (auto)
    ///         "name": "Client"
    ///     }
    ///
    /// </remarks>
    /// <returns>User role.</returns>
    /// <response code="201">User role.</response>
    /// <response code="400">If the user role was not found.</response>
    [Authorize]
    [Tags(tags: "UserRoles")]
    [ProducesResponseType(statusCode: StatusCodes.Status201Created)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<ActionResult<UserRoleEntity>> Create([FromBody] UserRoleEntity userRole)
    {
        if (userRole is not null) await _repository.CreateAsync(entity: userRole);

        return Ok();
    }

    /// <summary>
    /// Update user role.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     PUT /UserRoles
    ///     {
    ///         "id": 1,
    ///         "name": "Employee"
    ///     }
    ///
    /// </remarks>
    /// <response code="204">The object has been successfully modified.</response>
    /// <response code="400">If an error has occurred.</response>
    [Authorize]
    [Tags(tags: "UserRoles")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [HttpPut]
    public async Task<ActionResult> Update([FromBody] UserRoleEntity userRole)
    {
        if (userRole is not null) await _repository.UpdateAsync(entity: userRole);

        return NoContent();
    }

    /// <summary>
    /// Delete user role.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     DELETE /UserRoles/Id=1
    ///
    /// </remarks>
    /// <response code="204">The object has been successfully deleted.</response>
    /// <response code="400">If an error has occurred.</response>
    [Authorize]
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