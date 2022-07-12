namespace Victory.Services.API.Controllers;

[Produces(contentType: "application/json")]
[ApiController]
[Route(template: "[controller]")]
public class MailSubscribersController : ControllerBase
{
    private readonly IMailSubscriberRepositoryService _repository;

    public MailSubscribersController(IMailSubscriberRepositoryService repository) => _repository = repository;

    /// <summary>
    /// Get all mail subscribers.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /MailSubscribers
    ///
    /// </remarks>
    /// <returns>Return all mail subscribers.</returns>
    /// <response code="200">Mail subscribers list.</response>
    /// <response code="404">If the mail subscribers was not found.</response>
    [AllowAnonymous]
    [Tags(tags: "MailSubscribers")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MailSubscriberEntity>>> GetList() =>
        await _repository.GetMailSubscriberListAsync() is IEnumerable<MailSubscriberEntity> mailSubscribers
        ? Ok(value: mailSubscribers)
        : NotFound();

    /// <summary>
    /// Get mail subscriber by Id
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /MailSubscribers/Id=1
    ///
    /// </remarks>
    /// <param name="id">Id.</param>
    /// <returns>Mail subscriber.</returns>
    /// <response code="200">Mail subscriber.</response>
    /// <response code="404">If the mail subscriber was not found.</response>
    [Authorize]
    [Tags(tags: "MailSubscribers")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet(template: "Id={id}")]
    public async Task<ActionResult<MailSubscriberEntity>> Get(int id) =>
        await _repository.GetMailSubscriberAsync(id) is MailSubscriberEntity mailSubscribers
        ? Ok(value: mailSubscribers)
        : NotFound();

    /// <summary>
    /// Create mail subscriber.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     POST /MailSubscribers
    ///     {
    ///         "id": 0, (auto)
    ///         "mail": "example@bk.com"
    ///     }
    ///
    /// </remarks>
    /// <returns>Mail subscriber.</returns>
    /// <response code="201">Mail subscriber.</response>
    /// <response code="400">If an error has occurred.</response>
    [AllowAnonymous]
    [Tags(tags: "MailSubscribers")]
    [ProducesResponseType(statusCode: StatusCodes.Status201Created)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<ActionResult<MailSubscriberEntity>> Create([FromBody] MailSubscriberEntity mailSubscriber)
    {
        if (mailSubscriber is not null) await _repository.CreateAsync(entity: mailSubscriber);

        return Ok();
    }

    /// <summary>
    /// Update mail subscriber.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     PUT /MailSubscribers
    ///     {
    ///         "id": 1,
    ///         "mail": "example@bk.com"
    ///     }
    ///
    /// </remarks>
    /// <response code="204">The object has been successfully modified.</response>
    /// <response code="400">If an error has occurred.</response>
    [Authorize]
    [Tags(tags: "MailSubscribers")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [HttpPut]
    public async Task<ActionResult> Update([FromBody] MailSubscriberEntity mailSubscriber)
    {
        if (mailSubscriber is not null) await _repository.UpdateAsync(entity: mailSubscriber);

        return NoContent();
    }

    /// <summary>
    /// Delete mail subscriber.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     DELETE /MailSubscribers/Id=1
    ///
    /// </remarks>
    /// <response code="204">The object has been successfully deleted.</response>
    /// <response code="400">If an error has occurred.</response>
    [Authorize]
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