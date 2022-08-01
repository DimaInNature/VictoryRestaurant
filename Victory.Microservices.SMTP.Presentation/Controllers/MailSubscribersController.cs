namespace Victory.Microservices.SMTP.Presentation.Controllers;

[Produces(contentType: "application/json")]
[ApiController]
[Route(template: "[controller]")]
public class MailSubscribersController : ControllerBase
{
    private readonly IMailSubscriberService _mailSubscriberService;

    public MailSubscribersController(IMailSubscriberService mailSubscriberService) =>
        _mailSubscriberService = mailSubscriberService;

    /// <summary>
    /// Get mail subscribers.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /MailSubscribers
    ///
    /// </remarks>
    /// <returns>Return all mail subscribers.</returns>
    /// <response code="200">Mail subscribers list.</response>
    [Tags(tags: "MailSubscriber")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MailSubscriberEntity>>> GetList()
    {
        var result = await _mailSubscriberService.GetAllAsync();

        return result.Any() is false ? NotFound() : Ok(value: result);
    }

    /// <summary>
    /// Get mail subscriber by Id.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /MailSubscribers/1
    ///
    /// </remarks>
    /// <param name="id">Id.</param>
    /// <returns>Mail subscriber.</returns>
    /// <response code="200">Mail subscriber.</response>
    /// <response code="404">If the mail subscriber was not found.</response>
    [Tags(tags: "MailSubscriber")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet(template: "{id}")]
    public async Task<ActionResult<MailSubscriberEntity>> Get(int id)
    {
        var result = await _mailSubscriberService.GetAsync(id);

        return result is not null ? Ok(value: result) : NotFound();
    }

    /// <summary>
    /// Get mail subscriber by mail.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /MailSubscribers/Example@bk.com
    ///
    /// </remarks>
    /// <param name="mail">Mail.</param>
    /// <returns>Mail subscriber.</returns>
    /// <response code="200">Mail subscriber.</response>
    /// <response code="404">If the mail subscriber was not found.</response>
    [Tags(tags: "MailSubscriber")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet(template: "{mail}")]
    public async Task<ActionResult<MailSubscriberEntity>> Get(string mail)
    {
        var result = await _mailSubscriberService.GetAsync(
            predicate: mailSubscriber => mailSubscriber.Mail == mail);

        return result is not null ? Ok(value: result) : NotFound();
    }

    /// <summary>
    /// Create mail subscriber.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     POST /MailSubscribers
    ///     {
    ///         "id": 0,
    ///         "mail": "Example@bk.com"
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Created.</response>
    [Tags(tags: "MailSubscriber")]
    [ProducesResponseType(statusCode: StatusCodes.Status201Created)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<ActionResult<MailSubscriberEntity>> Create(
        [FromBody] MailSubscriberEntity mailSubscriber)
    {
        if (mailSubscriber is not null)
            await _mailSubscriberService.CreateAsync(entity: mailSubscriber);

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
    ///         "mail": "Example@bk.com"
    ///     }
    ///
    /// </remarks>
    /// <response code="204">The object has been successfully modified.</response>
    [Tags(tags: "MailSubscriber")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [HttpPut]
    public async Task<ActionResult> Update(
        [FromBody] MailSubscriberEntity mailSubscriber)
    {
        if (mailSubscriber is not null)
            await _mailSubscriberService.UpdateAsync(entity: mailSubscriber);

        return NoContent();
    }

    /// <summary>
    /// Delete mail subscriber.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     DELETE /MailSubscribers/1
    ///
    /// </remarks>
    /// <response code="204">The object has been successfully deleted.</response>
    [Tags(tags: "MailSubscriber")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [HttpDelete(template: "{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _mailSubscriberService.DeleteAsync(id);

        return NoContent();
    }
}