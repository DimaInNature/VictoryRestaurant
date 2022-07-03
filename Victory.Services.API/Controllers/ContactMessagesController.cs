namespace Victory.Services.API.Controllers;

[Produces(contentType: "application/json")]
[ApiController]
[Route(template: "[controller]")]
public class ContactMessagesController : ControllerBase
{
    private readonly IContactMessageFacadeService _repository;

    public ContactMessagesController(IContactMessageFacadeService repository) => _repository = repository;

    /// <summary>
    /// Get all contact messages.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /ContactMessages
    ///
    /// </remarks>
    /// <returns>Return all contact messages.</returns>
    /// <response code="200">Contact messages list.</response>
    /// <response code="404">If the contact messages was not found.</response>
    [Tags(tags: "ContactMessages")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ContactMessageEntity>>> GetList() =>
        await _repository.GetContactMessageListAsync() is IEnumerable<ContactMessageEntity> contactMessages
        ? Ok(value: contactMessages)
        : NotFound();

    /// <summary>
    /// Get contact message by Id.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /ContactMessages/Id=1
    ///
    /// </remarks>
    /// <param name="id">Id.</param>
    /// <returns>Contact message.</returns>
    /// <response code="200">Contact message.</response>
    /// <response code="404">If the contact message was not found.</response>
    [Tags(tags: "ContactMessages")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet(template: "Id={id}")]
    public async Task<ActionResult<ContactMessageEntity>> Get(int id) =>
        await _repository.GetContactMessageAsync(id) is ContactMessageEntity contactMessage
        ? Ok(value: contactMessage)
        : NotFound();

    /// <summary>
    /// Create contact message.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     POST /ContactMessages
    ///     {
    ///         "id": 0, (auto)
    ///         "name": "Oleg",
    ///         "mail": "example@bk.com",
    ///         "phone": "23-45-67",
    ///         "message": "MyMessage"
    ///     }
    ///
    /// </remarks>
    /// <returns>Contact message.</returns>
    /// <response code="201">Contact message.</response>
    /// <response code="400">If an error has occurred.</response>
    [Tags(tags: "ContactMessages")]
    [ProducesResponseType(statusCode: StatusCodes.Status201Created)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<ActionResult<ContactMessageEntity>> Create([FromBody] ContactMessageEntity contactMessage)
    {
        if (contactMessage is not null) await _repository.CreateAsync(entity: contactMessage);

        return Ok();
    }

    /// <summary>
    /// Update contact message.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     PUT /ContactMessages
    ///     {
    ///         "id": 1,
    ///         "name": "Oleg",
    ///         "mail": "example@bk.com",
    ///         "phone": "23-45-67",
    ///         "message": "MyMessage"
    ///     }
    ///
    /// </remarks>
    /// <response code="204">The object has been successfully modified.</response>
    /// <response code="400">If an error has occurred.</response>
    [Tags(tags: "ContactMessages")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [HttpPut]
    public async Task<ActionResult> Update([FromBody] ContactMessageEntity contactMessage)
    {
        if (contactMessage is not null) await _repository.UpdateAsync(entity: contactMessage);

        return NoContent();
    }

    /// <summary>
    /// Delete contact message.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     DELETE /ContactMessages/Id=1
    ///
    /// </remarks>
    /// <response code="204">The object has been successfully deleted.</response>
    /// <response code="400">If an error has occurred.</response>
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