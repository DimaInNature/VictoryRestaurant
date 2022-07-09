namespace Victory.Services.API.Controllers;

[Produces(contentType: "application/json")]
[ApiController]
[Route(template: "[controller]")]
public class TablesController : ControllerBase
{
    private readonly ITableFacadeService _repository;

    public TablesController(ITableFacadeService repository) => _repository = repository;

    /// <summary>
    /// Get all tables.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /Tables
    ///
    /// </remarks>
    /// <returns>Return all tables.</returns>
    /// <response code="200">Tables list.</response>
    /// <response code="404">If the tables was not found.</response>
    [AllowAnonymous]
    [Tags(tags: "Tables")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TableEntity>>> GetList() =>
        await _repository.GetTableListAsync() is IEnumerable<TableEntity> tables
        ? Ok(value: tables)
        : NotFound();

    /// <summary>
    /// Get all tables by number.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /Tables/Number=1
    ///
    /// </remarks>
    /// <returns>Tables list.</returns>
    /// <response code="200">Table list.</response>
    /// <response code="404">If the tables was not found.</response>
    [AllowAnonymous]
    [Tags(tags: "Tables")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet("Number={number}")]
    public async Task<ActionResult<IEnumerable<TableEntity>>> GetList(int number) =>
        await _repository.GetTableListAsync(number) is IEnumerable<TableEntity> tables
        ? Ok(value: tables)
        : NotFound();

    /// <summary>
    /// Get all tables by status.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /Tables/Status=Free
    ///
    /// </remarks>
    /// <returns>Tables list.</returns>
    /// <response code="200">Tables list.</response>
    /// <response code="404">If the tables was not found.</response>
    [AllowAnonymous]
    [Tags(tags: "Tables")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet("Status={status}")]
    public async Task<ActionResult<IEnumerable<TableEntity>>> GetList(string status) =>
        await _repository.GetTableListAsync(status) is IEnumerable<TableEntity> tables
        ? Ok(value: tables)
        : NotFound();

    /// <summary>
    /// Get table by Id.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /Tables/Id=1
    ///
    /// </remarks>
    /// <param name="id">Id.</param>
    /// <returns>Table.</returns>
    /// <response code="200">Table.</response>
    /// <response code="404">If the table was not found.</response>
    [Authorize]
    [Tags(tags: "Tables")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet(template: "Id={id}")]
    public async Task<ActionResult<TableEntity>> Get(int id) =>
        await _repository.GetTableAsync(id) is TableEntity table
        ? Ok(value: table)
        : NotFound();

    /// <summary>
    /// Create table.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     POST /Tables
    ///     {
    ///         "id": 0, (auto)
    ///         "number": 1,
    ///         "status": "Free"
    ///     }
    ///
    /// </remarks>
    /// <returns>Table.</returns>
    /// <response code="201">Table.</response>
    /// <response code="400">If an error has occurred.</response>
    [Authorize]
    [Tags(tags: "Tables")]
    [ProducesResponseType(statusCode: StatusCodes.Status201Created)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<ActionResult<TableEntity>> Create([FromBody] TableEntity table)
    {
        if (table is not null) await _repository.CreateAsync(entity: table);

        return Ok();
    }

    /// <summary>
    /// Update table.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     PUT /Tables
    ///     {
    ///         "id": 1,
    ///         "number": 1,
    ///         "status": "Free"
    ///     }
    ///
    /// </remarks>
    /// <response code="204">The object has been successfully modified..</response>
    /// <response code="400">If an error has occurred.</response>
    [AllowAnonymous]
    [Tags(tags: "Tables")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [HttpPut]
    public async Task<ActionResult> Update([FromBody] TableEntity table)
    {
        if (table is not null) await _repository.UpdateAsync(entity: table);

        return NoContent();
    }

    /// <summary>
    /// Delete table.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     DELETE /Tables/Id=1
    ///
    /// </remarks>
    /// <response code="204">The object has been successfully deleted.</response>
    /// <response code="400">If an error has occurred.</response>
    [Authorize]
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