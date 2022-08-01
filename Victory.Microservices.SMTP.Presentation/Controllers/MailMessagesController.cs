namespace Victory.Microservices.SMTP.Presentation.Controllers;

[Consumes(contentType: "application/json")]
[Produces(contentType: "application/json")]
[ApiController]
[Route(template: "[controller]")]
public class MailMessagesController : ControllerBase
{
    private readonly ISMTPService _smtpService;

    public MailMessagesController(ISMTPService smtpService) => _smtpService = smtpService;

    /// <summary>
    /// Send a message to all subscribers to the mailing list.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     POST /Send/All
    ///     {
    ///         "subject": "Hello",
    ///         "text": "World"
    ///     }
    ///
    /// </remarks>
    /// <response code="204">Success.</response>
    /// <response code="400">If an error has occurred.</response>
    [Tags(tags: "Mailing")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [HttpPost(template: "/Send/All")]
    public async Task<ActionResult> SendAll(EmailMessage message)
    {
        await _smtpService.SendAllAsync(message);

        return Ok();
    }
}