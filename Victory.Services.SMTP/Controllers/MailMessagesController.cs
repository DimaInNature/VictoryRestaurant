namespace Victory.Services.SMTP.Controllers;

[Consumes(contentType: "application/json")]
[Produces(contentType: "application/json")]
[ApiController]
[Route(template: "[controller]")]
public class MailMessagesController : ControllerBase
{
    private readonly EmailMailingService _emailService;

    public MailMessagesController(EmailMailingService emailService) => _emailService = emailService;

    /// <summary>
    /// Send a message to all subscribers to the mailing list.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     POST /Send/All
    ///     {
    ///         "subject": "Victory",
    ///         "text": "Hello"
    ///     }
    ///
    /// </remarks>
    /// <response code="204">Success.</response>
    /// <response code="400">If an error has occurred.</response>
    [Tags(tags: "Send")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [HttpPost(template: "/Send/All")]
    public async Task<ActionResult> SendAll(EmailMessage message)
    {
        await _emailService.SendAllAsync(message);

        return Ok();
    }
}